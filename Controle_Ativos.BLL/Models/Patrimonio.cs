using System;
using System.Collections.Generic;
using System.Text;

namespace Controle_Ativos.BLL.Models
{
    public class Patrimonio : Entidade
    {
        
        public string Descricao { get; set; }

        public DateTime DataAquisicao { get; set; }

        public DateTime DataSaida { get; set; }

        public int NumeroPatrimonio { get; set; }

        public double Valor { get; set; }

        public int Ativo { get; set; }

        public List<MovimentacaoPatrimonio> MovimentacaoPatrimonios { get; set; } = new List<MovimentacaoPatrimonio>();
        // Falta a Foreign key do tipo patrimonio

    }
}
