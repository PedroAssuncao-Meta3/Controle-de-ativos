using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Ativos.ViewModel
{
    public class ColaboradorViewModel
    {

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Nome do Colaborador")]
        [StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 4)]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "CPF")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter {1} caracteres", MinimumLength = 14)]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cargo { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        [Display(Name = "Data do Nascimento")]
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Endereço { get; set; }

        [Display(Name = "Cliente")]
        public Guid ClienteId { get; set; }

        public ClienteViewModel Cliente { get; set; }

        public List<ClienteViewModel> Clientes { get; set; } = new List<ClienteViewModel>();

        //public List<MovimentacaoPatrimonio> MovimentacaoPatrimonios { get; set; } = new List<MovimentacaoPatrimonio>();
    }
}
