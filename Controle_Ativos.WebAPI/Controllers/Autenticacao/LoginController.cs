using Controle_Ativos.BLL.Interfaces.Servicos.Login;
using Controle_Ativos.BLL.Models.Negocio;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Controle_Ativos.WebAPI.Controllers
{
    /// <summary>
    /// Serviço de Login
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IUsuarioServico _usuarioServico;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="usuarioServico"></param>
        public LoginController(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        /// <summary>
        /// Realizar login Usuário
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("Logar")]
        public ActionResult Logar(Login login)
        {
            try
            {
                var usuario = _usuarioServico.LogarUsuario(login.NomeUsuario, login.Senha);
                return Ok(usuario);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }            
        }

        /// <summary>
        /// Realizar login Usuário
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("AlterarSenha")]
        public ActionResult AlterarSenha(Login login)
        {
            try
            {
                var usuario = _usuarioServico.LogarUsuario(login.NomeUsuario, login.Senha);
                usuario.Senha = login.NovaSenha;
                _usuarioServico.Atualizar(usuario);
                return Ok(usuario);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
