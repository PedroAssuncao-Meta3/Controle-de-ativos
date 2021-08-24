using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Controle_Ativos.Models
{
    public class UsuarioViewModel
    {

        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 4)]
        [DisplayName("Nome Completo")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Login para Acesso")]
        public string Login { get; set; }


        [StringLength(500, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        [DisplayName("Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }


        [DisplayName("Ativo")]
        public bool Ativo { get; set; }


        [DisplayName("Administrador")]
        public bool Admin { get; set; }

    }
}
