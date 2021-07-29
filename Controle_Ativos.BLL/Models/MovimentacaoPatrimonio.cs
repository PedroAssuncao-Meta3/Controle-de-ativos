using System;
using System.Collections.Generic;
using System.Text;

namespace Controle_Ativos.BLL.Models
{
    public class MovimentacaoPatrimonio : Entidade
    {
        public DateTime DataIncio { get; set; }

        public DateTime DataFechamento { get; set; }

        public string Observacao { get; set; }



        public Guid ColaboradorId { get; set; }

        public Colaborador Colaborador { get; set; }


        public Guid PatrimonioId { get; set; }

        public Patrimonio Patrimonio { get; set; }



        public Guid TipoMovimentoId { get; set; }

        public TipoMovimento TipoMovimento { get; set; }
        // Falta a foreign key do  contrato
    }
}
