using Controle_Ativos.BLL.Models.Login;

namespace Controle_Ativos.BLL.Interfaces.Repositorio.Login
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Usuario LogarUsuario(string login, string senha, bool excessao = false);
        bool LoginExistente(Usuario usuario);
        bool LoginExistente(string login);
        int QtdeUsuarios();
    }
}
