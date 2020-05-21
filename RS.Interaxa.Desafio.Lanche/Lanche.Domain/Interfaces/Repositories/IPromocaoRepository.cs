using Lanche.Domain.Models;
using System.Collections.Generic;

namespace Lanche.Domain.Interfaces.Repositories
{
    public interface IPromocaoRepository : IRepository<Promocao>
    {
        #region Métodos utilizando Procedures
        IEnumerable<Promocao> SP_ListAll();

        Promocao SP_GetById(int? id);

        #endregion
    }
}
