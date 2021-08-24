using Controle_Ativos.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Controle_Ativos.BLL.Interfaces.Servicos.Login
{
    public interface IService<TEntity> : IDisposable where TEntity : Entidade
    {
        void Adicionar(TEntity Entidade);

        void AdicionarLista(List<TEntity> listaEntidade);

        TEntity ObterPrimeiroRegistro();

        TEntity ObterPorId(Guid Id);

        List<TEntity> ObterTodos();

        void Atualizar(TEntity Entidade);

        void AtualizarLista(List<TEntity> listaEntidade);

        void Remover(Guid id);

        void RemoverTodos();

        void RemoverLista(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);

        bool ExisteRegistro(TEntity Entidade);

        public bool ExisteRegistro(Guid id);
    }
}
