using Lanche.Application.Interfaces.Services;
using Lanche.Domain.Interfaces.Repositories;
using Lanche.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Lanche.Application.Services
{
    public class IngredienteService : IIngredienteService, IDisposable
    {
        private readonly IIngredienteRepository _repository;

        public IngredienteService(IIngredienteRepository repository)
        {
            _repository = repository;
        }

        #region Métodos utilizando Procedures
        public IEnumerable<Ingrediente> SP_ListAll()
        {
            return _repository.SP_ListAll();
        }

        public Ingrediente SP_GetById(int? id)
        {
            if (id == null) return null;

            return _repository.SP_GetById(id);
        }
        #endregion

        public void Add(Ingrediente entity)
        {
            //TODO: Adicionar regra de negócio

            _repository.Add(entity);
        }

        public void AddRange(IEnumerable<Ingrediente> entities)
        {
            _repository.AddRange(entities);
        }

        public IEnumerable<Ingrediente> Find(Expression<Func<Ingrediente, bool>> predicate)
        {
            return _repository.Find(predicate);
        }

        public Ingrediente Get(int? id)
        {
            if (id == null) return null;

            return _repository.Get(id);
        }

        public IEnumerable<Ingrediente> GetAll()
        {
            return _repository.GetAll();
        }

        public void Remove(Ingrediente entity)
        {
            _repository.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Ingrediente> entities)
        {
            _repository.RemoveRange(entities);
        }

        public void Update(Ingrediente entity)
        {
            _repository.Update(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
