using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Ativos.ViewModel
{
    public class AtributoXPatrimonioViewModel
    {

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Descrição do atributo:")]
        public string Conteudo { get; set; }
        
        
        public Guid AtributoId { get; set; }

        public AtributoViewModel Atributo { get; set; }


        public Guid PatrimonioId { get; set; }

        public PatrimonioViewModel Patrimonio { get; set; }


        public List<PatrimonioViewModel> Patrimonios { get; set; } = new List<PatrimonioViewModel>();
        public List<AtributoViewModel> Atributos { get; set; } = new List<AtributoViewModel>();
    }
}
