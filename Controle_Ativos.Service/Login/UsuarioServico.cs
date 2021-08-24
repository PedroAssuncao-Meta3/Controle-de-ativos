using Controle_Ativos.BLL.Interfaces.Repositorio.Login;
using Controle_Ativos.BLL.Interfaces.Servicos.Login;
using Controle_Ativos.BLL.Models.Login;

namespace Controle_Ativos.Service.Global
{
    public class UsuarioServico : ServiceBase<Usuario>, IUsuarioServico
    {
        protected readonly IUsuarioRepositorio _UsuarioRepositorio;

        public UsuarioServico(IUsuarioRepositorio repositorio) : base(repositorio)
        {
            _UsuarioRepositorio = repositorio;
        }

        public Usuario LogarUsuario(string nomeUsuario, string senha)
        {
            return _UsuarioRepositorio.LogarUsuario(nomeUsuario, senha);
        }

        public bool LoginExistente(Usuario usuario)
        {
            return _UsuarioRepositorio.LoginExistente(usuario);
        }

        public bool LoginExistente(string login)
        {
            return _UsuarioRepositorio.LoginExistente(login);
        }
    }
}