using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Lanche.Application.Interfaces.Services
{
    public interface ILancheService
    {
        #region Métodos utilizando Procedures
        IEnumerable<Domain.Models.Lanche> SP_ListAll();

        Domain.Models.Lanche SP_GetById(int? id);

        #endregion

        Domain.Models.Lanche Get(int? id);
        IEnumerable<Domain.Models.Lanche> GetAll();
        IEnumerable<Domain.Models.Lanche> GetAllEager();
        IEnumerable<Domain.Models.Lanche> Find(Expression<Func<Domain.Models.Lanche, bool>> predicate);

        void Add(Domain.Models.Lanche entity);
        void AddRange(IEnumerable<Domain.Models.Lanche> entities);

        void Remove(Domain.Models.Lanche entity);
        void RemoveRange(IEnumerable<Domain.Models.Lanche> entities);

        void Update(Domain.Models.Lanche entity);
    }
}
