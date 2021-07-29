using Controle_Ativos.BLL.Interfaces;
using Controle_Ativos.BLL.Models;
using Controle_Ativos.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controle_Ativos.Data.Repositorio
{
    public class ColaboradorRepositorio : Repositorio<Colaborador>, IColaboradorRepositorio
    {
        public ColaboradorRepositorio(DBContexto context) : base(context) { }


    }
}
