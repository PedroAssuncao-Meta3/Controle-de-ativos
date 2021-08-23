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
    public class PatrimonioRepositorio : Repositorio<Patrimonio>, IPatrimonioRepositorio
    {
        public PatrimonioRepositorio(DBContexto context) : base(context) { }

        public AtributoXPatrimonio ObterPrimeiroPatrimonio(Guid id)
        {
            return Db.AtributosXPatrimonios.Where(x => x.PatrimonioId == id).FirstOrDefault();
        }
        public List<TipoPatrimonio> RecuperaListaTipoPatrimonio()
        {
            return Db.TiposPatrimonio.ToList();
        }

        public override List<Patrimonio> ObterTodos()
        {
            return Db.Patrimonios.Include(x => x.TipoPatrimonio).ToList();
        }

        public override Patrimonio ObterPorId(Guid id)
        {
            return Db.Patrimonios.Where(x => x.Id == id).Include(x => x.TipoPatrimonio).Include(x => x.Ativo).FirstOrDefault();
        }

        public double ValorTotal()
        {
            var objPatGroup = from pat in Db.Patrimonios
                              group pat by 1 into patGroup
                              select new
                              {
                                  Total = patGroup.Sum(item => item.Valor)
                              };
            return objPatGroup.FirstOrDefault().Total;
        }
        public int QtdePatrimonios()
        {
            return Db.Patrimonios.Count();
        }
    }
}



