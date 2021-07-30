using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Ativos.ViewModel
{
    public class PatrimonioViewModel
    {

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Nome Patrimonio:")]
        public string NumeroPatrimonio { get; set; }

        [Display(Name = "Descriçao do Patrimonio:")]
        public string Descricao { get; set; }

        [Display(Name = "Data de Aquisiçao:(se houver alguma)")]
        public DateTime? DataAquisicao { get; set; }

        [Display(Name = "Data de Saida:(se houver alguma)")]
        public DateTime? DataSaida { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Valor monetario do Patrimonio:")]
        public double Valor { get; set; } = 0;

        [Required(ErrorMessage = "Please select yes or no")]
        public bool Ativo { get; set; }

        

    }
}
