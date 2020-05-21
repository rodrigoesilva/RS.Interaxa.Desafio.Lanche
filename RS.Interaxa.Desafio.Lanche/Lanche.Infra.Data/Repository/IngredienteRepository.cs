using Lanche.Domain.Interfaces.Repositories;
using Lanche.Domain.Models;
using Lanche.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Lanche.Infra.Data.Repository
{
    public class IngredienteRepository : Repository<Ingrediente>, IIngredienteRepository
    {
        public IngredienteRepository(LancheContext ctx) : base(ctx)
        { }

        #region Métodos utilizando Procedures
        public IEnumerable<Ingrediente> SP_ListAll()
        {
            return _ctx.Ingredientes
                 .FromSql("sp_Ingredientes_ListAll");
        }

        public Ingrediente SP_GetById(int? id)
        {

            return _ctx.Ingredientes
                 .FromSql("sp_Ingredientes_ById @p0", id).FirstOrDefault();
        }
        #endregion

    }
}
