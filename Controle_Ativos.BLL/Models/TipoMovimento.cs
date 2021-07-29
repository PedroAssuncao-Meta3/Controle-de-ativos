using System;
using System.Collections.Generic;
using System.Text;

namespace Controle_Ativos.BLL.Models
{
    public class TipoMovimento : Entidade
    {
        public string Descricao { get; set; }

        public List<MovimentacaoPatrimonio> MovimentacaoPatrimonios { get; set; } = new List<MovimentacaoPatrimonio>();
    }
}
