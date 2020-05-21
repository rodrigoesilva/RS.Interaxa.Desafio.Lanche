using Lanche.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Lanche.Application.Interfaces.Services
{
    public interface IIngredienteService
    {
        #region Métodos utilizando Procedures
        IEnumerable<Ingrediente> SP_ListAll();

        Ingrediente SP_GetById(int? id);

        #endregion


        Ingrediente Get(int? id);
        IEnumerable<Ingrediente> GetAll();
        IEnumerable<Ingrediente> Find(Expression<Func<Ingrediente, bool>> predicate);
        void Add(Ingrediente entity);
        void AddRange(IEnumerable<Ingrediente> entities);

        void Remove(Ingrediente entity);
        void RemoveRange(IEnumerable<Ingrediente> entities);

        void Update(Ingrediente entity);
    }
}
