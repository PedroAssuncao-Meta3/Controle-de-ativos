using Controle_Ativos.BLL.Interfaces;
using Controle_Ativos.BLL.Models;
using Controle_Ativos.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controle_Ativos.Data.Repositorio
{
    public class AtributoXPatrimonioRepositorio : Repositorio<AtributoXPatrimonio>, IAtributoXPatrimonioRepositorio
    {
        public AtributoXPatrimonioRepositorio(DBContexto context) : base(context) { }

        public List<Patrimonio> RecuperaListaPatrimonio()
        {
            return Db.Patrimonios.ToList();
        }

        public List<Atributo> RecuperaListaAtributo()
        {
            return Db.Atributos.ToList();
        }

        public override List<AtributoXPatrimonio> ObterTodos()
        {
            return Db.AtributosXPatrimonios.Include(x => x.Patrimonio).Include(x => x.Atributo).ToList();
        }

        public override AtributoXPatrimonio ObterPorId(Guid id)
        {
            return Db.AtributosXPatrimonios.Include(x => x.Patrimonio).Include(x => x.Atributo).FirstOrDefault();
        }
    }
}
