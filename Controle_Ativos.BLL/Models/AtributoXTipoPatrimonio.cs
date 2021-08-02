using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Ativos.BLL.Models
{
    public class AtributoXTipoPatrimonio : Entidade
    {

        public Guid AtributoId { get; set; }

        public Atributo Atributo { get; set; }
        
        
        public Guid TipoPatrimonioId { get; set; }

        public TipoPatrimonio TipoPatrimonio{ get; set; }
    
    
    
    
    
    }
}
