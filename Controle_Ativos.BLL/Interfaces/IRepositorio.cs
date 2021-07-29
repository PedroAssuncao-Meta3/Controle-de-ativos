using Controle_Ativos.BLL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;

namespace Controle_Ativos.BLL.Interfaces
{
    public interface IRepositorio<TEntity> : IDisposable where TEntity : Entidade
    {
        void Adicionar(TEntity entity);

        void AdicionarLista(List<TEntity> listaEntidade);

        TEntity ObterPrimeiroRegistro();

        TEntity ObterPorId(Guid id);

        List<TEntity> ObterTodos();

        void Atualizar(TEntity entity);

        void Remover(Guid id);

        void RemoverTodos();

        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);

        int SaveChanges();

        void AtualizarLista(List<TEntity> listaEntidade);

        int ExecutarQuery(string query, SqlParameter[] parametros);

        bool ExisteRegistro(TEntity Entidade);

        bool ExisteRegistro(Guid id);
        void Atualizar(TEntity entidade, bool validarRegistro);
        void RemoverLista(Expression<Func<TEntity, bool>> predicate);
    }
}
