using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Lanche.Domain.Interfaces.Repositories;
using Lanche.Domain.Models;

namespace Lanche.UnitTest.Tests
{
    public class LancheIngredienteRepositoryTest : ILancheIngredienteRepository
    {
        public void Add(LancheIngrediente entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<LancheIngrediente> entities)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LancheIngrediente> Find(Expression<Func<LancheIngrediente, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public LancheIngrediente Get(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LancheIngrediente> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(LancheIngrediente entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<LancheIngrediente> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(LancheIngrediente entity)
        {
            throw new NotImplementedException();
        }
    }
}