using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Ativos.ViewModel
{

    public class AtributoXTipoPatrimonioViewModel
    {

        [Key]
        public Guid Id { get; set; }


        public Guid AtributoId { get; set; }

        public AtributoViewModel Atributo { get; set; }


        public Guid TipoPatrimonioId { get; set; }

        public TipoPatrimonioViewModel TipoPatrimonio { get; set; }


        public List<TipoPatrimonioViewModel> TipoPatrimonios { get; set; } = new List<TipoPatrimonioViewModel>();
        public List<AtributoViewModel> Atributos { get; set; } = new List<AtributoViewModel>();
    }
}
