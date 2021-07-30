using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Ativos.BLL.Models
{
    public class Atributo : Entidade
    {

        public string Descricao { get; set; }


        public List<AtributoXPatrimonio> AtributoXPatrimonios { get; set; } = new List<AtributoXPatrimonio>();
        public List<AtributoXTipoPatrimonio> AtributoXTipoPatrimonios { get; set; } = new List<AtributoXTipoPatrimonio>();
    }
}
