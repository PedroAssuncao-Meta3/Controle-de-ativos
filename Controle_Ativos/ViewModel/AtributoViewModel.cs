using Controle_Ativos.BLL.Models;
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
        [Display(Name = "Descrição do atributo:")]
        public string Descricao { get; set; }

        public Guid AtributoXPatrimonioId { get; set; }

        public AtributoXPatrimonioViewModel AtributoXPatrimonio { get; set; }

        public List<AtributoXPatrimonioViewModel> AtributoXPatrimonios { get; set; } = new List<AtributoXPatrimonioViewModel>();

        public Guid AtributoXTipoPatrimonioId { get; set; }

        public AtributoXTipoPatrimonioViewModel AtributoXTipoPatrimonio { get; set; }

        public List<AtributoXTipoPatrimonioViewModel> AtributoXTipoPatrimonios { get; set; } = new List<AtributoXTipoPatrimonioViewModel>();


    }
}
