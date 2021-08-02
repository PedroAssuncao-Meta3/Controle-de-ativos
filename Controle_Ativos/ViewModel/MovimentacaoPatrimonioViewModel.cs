using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Controle_Ativos.ViewModel
{
    public class MovimentacaoPatrimonioViewModel
    {
        #region CamposTabela
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Data de inicio do Empréstimo:")]
        public DateTime DataIncio { get; set; } = DateTime.Now;

        [Display(Name = "Data de fechamento do Emprestimo:(se houver alguma)")]
        public DateTime? DataFechamento { get; set; }

        [Display(Name = "(OPCIONAL)Observações do Empréstimo:")]
        public string Observacao { get; set; }

        [Display(Name = "Colaborador:")]
        public Guid ColaboradorId { get; set; }
        public ClienteViewModel Colaborador { get; set; }

        [Display(Name = "Patrimonio:")]
        public Guid PatrimonioId { get; set; }
        public ClienteViewModel Patrimonio { get; set; }
        
        [Display(Name = "Tipo de Movimentação:")]
        public Guid TipoMovimentacaoId { get; set; }
        public ClienteViewModel TipoMovimentacao { get; set; }
        #endregion
        
        
        #region ListasFK
        public List<TipoMovimentacaoViewModel> TipoMovimentacoes { get; set; } = new List<TipoMovimentacaoViewModel>();
        public List<PatrimonioViewModel> Patrimonios { get; set; } = new List<PatrimonioViewModel>();
        public List<ColaboradorViewModel> Colaboradores { get; set; } = new List<ColaboradorViewModel>();
        #endregion
    }
}
