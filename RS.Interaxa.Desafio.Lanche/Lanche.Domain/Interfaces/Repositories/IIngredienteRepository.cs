using Lanche.Domain.Models;
using System.Collections.Generic;

namespace Lanche.Domain.Interfaces.Repositories
{
    public interface IIngredienteRepository : IRepository<Ingrediente>
    {

        #region Métodos utilizando Procedures
        IEnumerable<Ingrediente> SP_ListAll();

        Ingrediente SP_GetById(int? id);

        #endregion
    }
}
