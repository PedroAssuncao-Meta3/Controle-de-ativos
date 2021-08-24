using Controle_Ativos.BLL.Models.Login;

namespace Controle_Ativos.BLL.Interfaces.Servicos.Login
{
    public interface IUsuarioServico : IService<Usuario>
    {
        Usuario LogarUsuario(string login, string senha);
        bool LoginExistente(Usuario usuario);
        bool LoginExistente(string login);
    }
}
