using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Ativos.BLL.Models
{
    public class Cliente : Entidade
    {

        public string Nome { get; set; }

        public List<Colaborador> Colaboradores { get; set; } = new List<Colaborador>();

    }
}
