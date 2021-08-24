using Controle_Ativos.BLL.Interfaces.Repositorio.Login;
using Controle_Ativos.BLL.Models.Login;
using Controle_Ativos.Data.Contexto;
using NETCore.Encrypt;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Controle_Ativos.Data.Repositorio
{

    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        private class LoginException : Exception
        {
            public LoginException() : base("Usuário ou senha inválido.") { }
        }

        public UsuarioRepositorio(DBContexto context) : base(context) { }

        public Usuario LogarUsuario(string login, string senha, bool excessao = false)
        {
            try
            {
                var aux = Db.Usuarios.Where(x => x.Login.ToLower() == login.ToLower() && x.Ativo == true);

                if (aux == null || aux.Count() <= 0)
                {
                    if (excessao)
                    {
                        throw new LoginException();
                    }
                    return null;
                }

                var usuario = aux.First();
                usuario.Senha = EncryptProvider.Base64Decrypt(usuario.Senha);

                if (usuario.Senha != senha)
                {
                    if (excessao)
                    {
                        throw new LoginException();
                    }
                    return null;
                }

                return usuario;
            }
            catch (LoginException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override void Adicionar(Usuario usuario)
        {
            ValidaLogin(usuario);
            usuario.Id = new Guid();
            usuario.Senha = EncryptProvider.Base64Encrypt(usuario.Senha);
            base.Adicionar(usuario);
        }

        public override void AdicionarLista(List<Usuario> listaUsuarios)
        {
            foreach (Usuario usuario in listaUsuarios)
            {
                ValidaLogin(usuario);
                usuario.Id = new Guid();
                usuario.Senha = EncryptProvider.Base64Encrypt(usuario.Senha);
            }
            base.AdicionarLista(listaUsuarios);
        }

        public override Usuario ObterPorId(Guid id)
        {
            var usuario = base.ObterPorId(id);
            usuario.Senha = EncryptProvider.Base64Decrypt(usuario.Senha);
            return usuario;
        }

        public override List<Usuario> ObterTodos()
        {
            var listaUsuario = base.ObterTodos();

            foreach (Usuario usuario in listaUsuario)
            {
                usuario.Senha = EncryptProvider.Base64Decrypt(usuario.Senha);
            }
            return listaUsuario;
        }

        public override void AtualizarLista(List<Usuario> listaUsuarios)
        {
            foreach (Usuario usuario in listaUsuarios)
            {
                ValidaLogin(usuario);
                usuario.Senha = EncryptProvider.Base64Decrypt(usuario.Senha);
            }
            base.AtualizarLista(listaUsuarios);
        }

        public override void Atualizar(Usuario usuario)
        {
            ValidaLogin(usuario);
            usuario.Senha = EncryptProvider.Base64Encrypt(usuario.Senha);
            base.Atualizar(usuario);
        }

        public int QtdeUsuarios()
        {
            return Db.Usuarios.Count();
        }

        public bool LoginExistente(Usuario usuario)
        {
            return Db.Usuarios.Any(x => x.Login == usuario.Login && x.Id != usuario.Id);
        }

        public bool LoginExistente(string login)
        {
            return Db.Usuarios.Any(x => x.Login == login);
        }

        private void ValidaLogin(Usuario usuario)
        {
            var aux = Db.Usuarios.Where(x => x.Login == usuario.Login && x.Id != usuario.Id);
            if (aux != null && aux.Count() > 0)
            {
                throw new Exception("Login já existente.");
            }
        }
    }
}