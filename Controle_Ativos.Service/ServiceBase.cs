using Controle_Ativos.BLL.Interfaces;
using Controle_Ativos.BLL.Interfaces.Servicos.Login;
using Controle_Ativos.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Controle_Ativos.Service
{

    public abstract class ServiceBase<TEntity> : IService<TEntity> where TEntity : Entidade
    {
        public readonly IRepositorio<TEntity> _repositorio;

        protected ServiceBase(IRepositorio<TEntity> repositorio)
        {
            _repositorio = repositorio;
        }

        public virtual void Adicionar(TEntity entitade)
        {
            _repositorio.Adicionar(entitade);
        }

        public virtual void AdicionarLista(List<TEntity> listaEntidade)
        {
            _repositorio.AdicionarLista(listaEntidade);
        }

        public virtual void Atualizar(TEntity entitade)
        {
            _repositorio.Atualizar(entitade);
        }

        public virtual void AtualizarLista(List<TEntity> listaEntidade)
        {
            _repositorio.AtualizarLista(listaEntidade);
        }

        public virtual IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return _repositorio.Buscar(predicate);
        }

        public virtual void Dispose()
        {
            _repositorio.Dispose();
        }

        public virtual bool ExisteRegistro(TEntity Entidade)
        {
            return _repositorio.ExisteRegistro(Entidade);
        }

        public virtual bool ExisteRegistro(Guid id)
        {
            return _repositorio.ExisteRegistro(id);
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return _repositorio.ObterPorId(id);
        }

        public virtual TEntity ObterPrimeiroRegistro()
        {
            return _repositorio.ObterPrimeiroRegistro();
        }

        public virtual List<TEntity> ObterTodos()
        {
            return _repositorio.ObterTodos();
        }

        public virtual void Remover(Guid id)
        {
            _repositorio.Remover(id);
        }

        public virtual void RemoverLista(Expression<Func<TEntity, bool>> predicate)
        {
            _repositorio.RemoverLista(predicate);
        }

        public virtual void RemoverTodos()
        {
            _repositorio.RemoverTodos();
        }
    }
}
