using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Controle_Ativos.Models
{
    public class LoginViewModel 
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Usuário")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Senha { get; set; }

        public string Mensagem { get; set; }

        public string UrlRetorno { get; set; }

    }
}
