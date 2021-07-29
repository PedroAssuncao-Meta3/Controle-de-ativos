using Controle_Ativos.BLL.Interfaces;
using Controle_Ativos.BLL.Models;
using Controle_Ativos.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controle_Ativos.Data.Repositorio
{
    public class TipoMovimentoRepositorio : Repositorio<TipoMovimento>, ITipoMovimentoRepositorio
    {
        public TipoMovimentoRepositorio(DBContexto context) : base(context) { }
    }
}
