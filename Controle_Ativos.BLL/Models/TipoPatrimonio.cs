using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Ativos.BLL.Models
{
    public class TipoPatrimonio : Entidade
    {

        public string Descricao { get; set; }


        public List<AtributoXTipoPatrimonio> AtributoXTipoPatrimonio { get; set; } = new List<AtributoXTipoPatrimonio>();

        public List<Patrimonio> Patrimonio { get; set; } = new List<Patrimonio>();
    }
}
