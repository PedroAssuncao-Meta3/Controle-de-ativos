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
    public class AtributoXTipoPatrimonioRepositorio : Repositorio<AtributoXTipoPatrimonio>, IAtributoXTipoPatrimonioRepositorio
    {
        public AtributoXTipoPatrimonioRepositorio(DBContexto context) : base(context) { }

        public List<TipoPatrimonio> RecuperaListaTipoPatrimonio()
        {
            return Db.TiposPatrimonio.ToList();
        }

        public List<AtributoXTipoPatrimonio> RecupeaListaAtributoDoTipoPatrimonio(Guid Id) {

            return Db.AtributosXTiposPatrimonio.Where(X => X.TipoPatrimonioId == Id).ToList();
        }

        public List<Atributo> RecuperaListaAtributo()
        {
            return Db.Atributos.ToList();
        }

        public override List<AtributoXTipoPatrimonio> ObterTodos()
        {
            return Db.AtributosXTiposPatrimonio.Include(X => X.Atributo).Include(x => x.TipoPatrimonio).ToList();
        }

    }
}
