using Lanche.Application.Interfaces.Services;
using Lanche.Domain.Interfaces.Repositories;
using Lanche.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Lanche.Application.Services
{
    public class PromocaoService : IPromocaoService, IDisposable
    {
        private readonly IPromocaoRepository _repository;

        public PromocaoService(IPromocaoRepository repository)
        {
            _repository = repository;
        }

        #region Métodos utilizando Procedures
        public IEnumerable<Promocao> SP_ListAll()
        {
            return _repository.SP_ListAll();
        }

        public Promocao SP_GetById(int? id)
        {
            if (id == null) return null;

            return _repository.SP_GetById(id);
        }
        #endregion
        public void Add(Promocao promocao)
        {
            _repository.Add(promocao);
        }

        public void AddRange(IEnumerable<Promocao> promocoes)
        {
            _repository.AddRange(promocoes);
        }

        public IEnumerable<Promocao> Find(Expression<Func<Promocao, bool>> promocao)
        {
            return _repository.Find(promocao);
        }

        public Promocao Get(int? id)
        {
            if (id == null) return null;

            return _repository.Get(id);
        }

        public IEnumerable<Promocao> GetAll()
        {
            return _repository.GetAll();
        }

        public void Remove(Promocao promocao)
        {
            _repository.Remove(promocao);
        }

        public void RemoveRange(IEnumerable<Promocao> promocoes)
        {
            _repository.RemoveRange(promocoes);
        }

        public void Update(Promocao promocao)
        {
            _repository.Update(promocao);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
