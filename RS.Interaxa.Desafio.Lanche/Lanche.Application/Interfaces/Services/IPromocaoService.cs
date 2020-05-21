using Lanche.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Lanche.Application.Interfaces.Services
{
    public interface IPromocaoService
    {
        #region Métodos utilizando Procedures
        IEnumerable<Promocao> SP_ListAll();

        Promocao SP_GetById(int? id);

        #endregion
        Promocao Get(int? id);
        IEnumerable<Promocao> GetAll();
        IEnumerable<Promocao> Find(Expression<Func<Promocao, bool>> predicate);

        void Add(Promocao entity);
        void AddRange(IEnumerable<Promocao> entities);

        void Remove(Promocao entity);
        void RemoveRange(IEnumerable<Promocao> entities);

        void Update(Promocao entity);
    }
}
