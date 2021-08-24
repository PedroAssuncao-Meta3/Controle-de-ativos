using Controle_Ativos.BLL.Interfaces.Repositorio.Login;
using Controle_Ativos.BLL.Models.Login;
using Controle_Ativos.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Controle_Ativos.Controllers.Autenticacao
{
    [AllowAnonymous]
    public class AutenticacaoController : Controller
    {
        private readonly IUsuarioRepositorio _UsuarioRepositorio;

        public AutenticacaoController(IUsuarioRepositorio UsuarioRepositorio)
        {
            _UsuarioRepositorio = UsuarioRepositorio;
        }
        public ActionResult Index()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        public ActionResult Login(string ReturnUrl)
        {
            var model = new LoginViewModel();
            model.UrlRetorno = ReturnUrl;
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                if (_UsuarioRepositorio.QtdeUsuarios() == 0 &&
                    loginModel.NomeUsuario.ToLower() == "meta" &&
                    loginModel.Senha.ToLower() == "meta")
                {
                    Usuario usuarioMaster = new Usuario();
                    usuarioMaster.Nome = "Meta Admin";
                    usuarioMaster.Login = "Meta";
                    usuarioMaster.Senha = "meta";
                    usuarioMaster.Email = "meta@meta3.com.br";
                    usuarioMaster.Admin = true;
                    usuarioMaster.Ativo = true;

                    _UsuarioRepositorio.Adicionar(usuarioMaster);
                }


                var usuario = _UsuarioRepositorio.LogarUsuario(loginModel.NomeUsuario, loginModel.Senha);

                if (usuario == null)
                {
                    loginModel.Mensagem = "Usuário ou Senha inválidos!";
                    return View("Login", loginModel);
                }
                else
                {               
                    Logar(usuario);

                    if (string.IsNullOrWhiteSpace(loginModel.UrlRetorno))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(loginModel.UrlRetorno);
                    }
                }
            }
            return View(loginModel);
        }

        public void Logar(Usuario usuario)
        {
            var claims = new List<Claim>
                {
                    new Claim("Usuario", usuario.Login),
                    new Claim("NomeUsuario", usuario.Nome),
                    new Claim("Id", usuario.Id.ToString()),
                    new Claim("Admin", usuario.Admin.ToString())
                };

            var identidadeDeUsuario = new ClaimsIdentity(claims, "Login");
            ClaimsPrincipal claimPrincipal = new ClaimsPrincipal(identidadeDeUsuario);

            var propriedadesDeAutenticacao = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTime.Now.ToLocalTime().AddHours(2),
                IsPersistent = true
            };

            Task.Run(async () =>
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, propriedadesDeAutenticacao);
            }).Wait();

        }

        public async Task<IActionResult> Deslogar()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            _ = Deslogar();
            return RedirectToAction("Login");
        }

        public class RetornoAlteraSenha
        {
            public bool SenhaValidada { get; set; } = true;

            public string ErroSenha { get; set; }

        }

        public RetornoAlteraSenha AlteraSenha(string senha, string novaSenha)
        {
            RetornoAlteraSenha retornovalidacao = new RetornoAlteraSenha();

            try
            {
                if ((!string.IsNullOrEmpty(senha)) && (!string.IsNullOrEmpty(novaSenha)))
                {
                    var login = HttpContext.User.Claims.Where(r => r.Type == "Usuario").FirstOrDefault()?.Value.ToString();

                    var usuario = _UsuarioRepositorio.LogarUsuario(login, senha);

                    if (usuario == null)
                    {
                        throw new Exception("Senha inválida");
                    }
                    else
                    {
                        usuario.Senha = novaSenha;
                        _UsuarioRepositorio.Atualizar(usuario);
                        retornovalidacao.ErroSenha = "Senha alterada com sucesso";
                        retornovalidacao.SenhaValidada = true;
                    }
                }
                else
                {
                    throw new Exception("Senha inválida!");
                }
            }
            catch (Exception ex)
            {
                retornovalidacao.ErroSenha = string.Format("Não foi possível alterar a senha: {0}", ex.Message);
                retornovalidacao.SenhaValidada = false;
            }
            return retornovalidacao;
        }

    }
}
