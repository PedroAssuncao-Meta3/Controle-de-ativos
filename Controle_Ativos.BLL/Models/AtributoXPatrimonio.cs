using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Ativos.BLL.Models
{
    public class AtributoXPatrimonio : Entidade
    {

        public string Conteudo { get; set; }


        public Guid AtributoId { get; set; }

        public Atributo Atributo { get; set; }

        
        public Guid PatrimonioId { get; set; }

        public Patrimonio Patrimonio { get; set; }
    }
}
