using Controle_Ativos.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controle_Ativos.BLL.Interfaces
{
    public interface IMovimentacaoPatrimonioRepositorio : IRepositorio<MovimentacaoPatrimonio>
    {
        int QtdeEmprestimos();
        List<Colaborador> RecuperaListaColaborador();
        List<TipoMovimentacao> RecuperaListaTipoMovimentacao();
        List<Patrimonio> RecuperaListaPatrimonio();
    }
}
