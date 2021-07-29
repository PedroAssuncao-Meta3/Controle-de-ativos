using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Ativos.BLL.Models
{
    public class Colaborador : Entidade
    {
        public string Nome { get; set; }

        public string CPF { get; set; }

        public Guid ClienteId { get; set; }

        public Cliente Cliente { get; set; }
    }
}
