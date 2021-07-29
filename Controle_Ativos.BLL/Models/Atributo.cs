using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Ativos.BLL.Models
{
    public class Atributo : Entidade
    {

        public string Descricao { get; set; }


        public List<AtributoXTipoPatrimonio> AtributoXTipoPatrimonio { get; set; } = new List<AtributoXTipoPatrimonio>();
    }
}
