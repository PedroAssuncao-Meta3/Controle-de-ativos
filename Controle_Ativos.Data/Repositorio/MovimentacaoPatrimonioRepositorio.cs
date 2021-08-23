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
    public class MovimentacaoPatrimonioRepositorio : Repositorio<MovimentacaoPatrimonio>, IMovimentacaoPatrimonioRepositorio
    {
        public MovimentacaoPatrimonioRepositorio(DBContexto context) : base(context) { }

        public List<Colaborador> RecuperaListaColaborador()
        {
            return Db.Colaboradores.ToList();
        }

        public List<TipoMovimentacao> RecuperaListaTipoMovimentacao()
        {
            return Db.TiposMovimento.ToList();
        }
        public List<Patrimonio> RecuperaListaPatrimonio()
        {
            return Db.Patrimonios.ToList();
        }

        public override List<MovimentacaoPatrimonio> ObterTodos()
        {
            return Db.MovimentacoesPatrimonios.Include(x => x.Colaborador).Include(x => x.Patrimonio).Include(x => x.TipoMovimento).ToList() ;
        }

        public override MovimentacaoPatrimonio ObterPorId(Guid id)
        {
            return Db.MovimentacoesPatrimonios.Where(x => x.Id == id).Include(x => x.Colaborador).Include(x => x.Patrimonio).Include(x => x.TipoMovimento).FirstOrDefault();
        }
        public int QtdeEmprestimos()
        {
            return Db.MovimentacoesPatrimonios.Count();
        }
    }
}
