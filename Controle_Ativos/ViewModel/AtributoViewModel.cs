using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Ativos.ViewModel
{
    public class AtributoViewModel
    {

        [Key]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Descriçao do atributo:")]
        public string Descricao { get; set; }

        //public List<AtributoXPatrimonio> AtributoXPatrimonios { get; set; } = new List<AtributoXPatrimonio>();
        //public List<AtributoXTipoPatrimonio> AtributoXTipoPatrimonios { get; set; } = new List<AtributoXTipoPatrimonio>();
    }
}
