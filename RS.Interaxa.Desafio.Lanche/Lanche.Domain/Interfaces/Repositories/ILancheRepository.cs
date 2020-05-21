using System.Collections.Generic;

namespace Lanche.Domain.Interfaces.Repositories
{
    public interface ILancheRepository : IRepository<Models.Lanche>
    {
        #region Métodos utilizando Procedures
        IEnumerable<Models.Lanche> SP_ListAll();

        Models.Lanche SP_GetById(int? id);

        #endregion
        IEnumerable<Models.Lanche> GetAllEager();
    }
}
