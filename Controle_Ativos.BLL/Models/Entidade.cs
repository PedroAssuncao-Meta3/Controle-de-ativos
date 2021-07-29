using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Ativos.BLL.Models
{
    public class Entidade
    {
        public Guid Id { get; set; }

        public Entidade()
        {
            Id = Guid.NewGuid();
        }
    }
}
