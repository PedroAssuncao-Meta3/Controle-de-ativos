using Controle_Ativos.BLL.Interfaces;
using Controle_Ativos.BLL.Models;
using Controle_Ativos.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controle_Ativos.Data.Repositorio
{
    public class TipoMovimentacaoRepositorio : Repositorio<TipoMovimentacao>, ITipoMovimentacaoRepositorio
    {
        public TipoMovimentacaoRepositorio(DBContexto context) : base(context) { }
    }
}
