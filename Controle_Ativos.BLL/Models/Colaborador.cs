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
        public string Cargo { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Endereço { get; set; }


        public Guid ClienteId { get; set; }

        public Cliente Cliente { get; set; }
    }
}
