using Controle_Ativos.BLL.Interfaces;
using Controle_Ativos.BLL.Models;
using Controle_Ativos.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Controle_Ativos.Data.Repositorio
{
    public abstract class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : Entidade, new()
    {
        protected readonly DBContexto Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repositorio(DBContexto db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate).ToList();
        }

        public virtual TEntity ObterPrimeiroRegistro()
        {
            return DbSet.FirstOrDefault();
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual List<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual void Adicionar(TEntity entidade)
        {
            DbSet.Add(entidade);
            SaveChanges();
        }

        public virtual void AdicionarLista(List<TEntity> listaEntidade)
        {
            DbSet.AddRange(listaEntidade);
            SaveChanges();
        }

        public virtual void AtualizarLista(List<TEntity> listaEntidade)
        {
            DbSet.UpdateRange(listaEntidade);
            SaveChanges();
        }
        public virtual void Atualizar(TEntity entidade)
        {
            Atualizar(entidade, true);
        }


        public virtual void Atualizar(TEntity entidade, bool validarRegistro)
        {
            if (validarRegistro && !ExisteRegistro(entidade))
            {
                throw new Exception("Registro não encontrado no banco de dados.");
            }

            DbSet.Update(entidade);
            SaveChanges();
        }

        public virtual void Remover(Guid id)
        {
            if (!ExisteRegistro(id))
            {
                throw new Exception("Registro não encontrado no banco de dados.");
            }

            DbSet.Remove(new TEntity { Id = id });
            SaveChanges();
        }

        public virtual void RemoverTodos()
        {
            DbSet.RemoveRange(DbSet);
            SaveChanges();
        }

        public void RemoverLista(Expression<Func<TEntity, bool>> predicate)
        {
            var aux = DbSet.AsNoTracking().Where(predicate);
            DbSet.RemoveRange(aux);
            SaveChanges();
        }

        public virtual bool ExisteRegistro(Guid id)
        {
            return ExisteRegistro(new TEntity { Id = id });
        }

        public virtual bool ExisteRegistro(TEntity entidade)
        {
            return Buscar(c => c.Id == entidade.Id).Any();
        }

        public virtual int ExecutarQuery(string query, SqlParameter[] parametros)
        {
            return Db.Database.ExecuteSqlRaw(query, parametros);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
