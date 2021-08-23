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
    public class ColaboradorRepositorio : Repositorio<Colaborador>, IColaboradorRepositorio
    {
        public ColaboradorRepositorio(DBContexto context) : base(context) { }

        public List<Cliente> RecuperaListaCliente()
        {
            return Db.Clientes.ToList();
        }

        public override List<Colaborador> ObterTodos()
        {
            return Db.Colaboradores.Include(c=> c.Cliente).ToList();
        }

        public override Colaborador ObterPorId(Guid id)
        {
            return Db.Colaboradores.Where(c => c.Id == id).Include(c => c.Cliente).FirstOrDefault();
        }

        public int QtdeColaboradores()
        {
            return Db.Colaboradores.Count();
        }

    }
}
