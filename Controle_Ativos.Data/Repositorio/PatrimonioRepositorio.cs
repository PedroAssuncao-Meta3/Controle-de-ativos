using Controle_Ativos.BLL.Interfaces;
using Controle_Ativos.BLL.Models;
using Controle_Ativos.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controle_Ativos.Data.Repositorio
{
    public class PatrimonioRepositorio : Repositorio<Patrimonio>, IPatrimonioRepositorio
    {
        public PatrimonioRepositorio(DBContexto context) : base(context) { }
    }
}
