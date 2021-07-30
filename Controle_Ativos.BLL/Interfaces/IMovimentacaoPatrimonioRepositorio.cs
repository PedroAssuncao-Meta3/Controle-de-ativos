using Controle_Ativos.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controle_Ativos.BLL.Interfaces
{
    public interface IMovimentacaoPatrimonioRepositorio : IRepositorio<MovimentacaoPatrimonio>
    {
        List<Colaborador> RecuperaListaColaborador();
        List<TipoMovimento> RecuperaListaTipoMovimentacao();
        List<Patrimonio> RecuperaListaPatrimonio();

    }
}
