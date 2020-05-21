using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Lanche.Domain.Interfaces.Repositories;

namespace Lanche.UnitTest.Tests
{
    public class LancheRepositoryTest : ILancheRepository
    {
        public void Add(Domain.Models.Lanche entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Domain.Models.Lanche> entities)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Models.Lanche> Find(Expression<Func<Domain.Models.Lanche, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Domain.Models.Lanche Get(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Models.Lanche> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Models.Lanche> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public void Remove(Domain.Models.Lanche entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Domain.Models.Lanche> entities)
        {
            throw new NotImplementedException();
        }

        public Domain.Models.Lanche SP_GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain.Models.Lanche> SP_ListAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Models.Lanche entity)
        {
            throw new NotImplementedException();
        }
    }
}
