using Lanche.Domain.Interfaces.Repositories;
using Lanche.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Lanche.Infra.Data.Repository
{
    public class LancheRepository : Repository<Domain.Models.Lanche>, ILancheRepository
    {
        public LancheRepository(LancheContext ctx) : base(ctx)
        { }

        #region Métodos utilizando Procedures
        public IEnumerable<Domain.Models.Lanche> SP_ListAll()
        {
            return _ctx.Lanches
                 .FromSql("sp_Lanches_ListAll");
        }

        public Domain.Models.Lanche SP_GetById(int? id)
        {

            return _ctx.Lanches
                 .FromSql("sp_Lanches_ById @p0", id).FirstOrDefault();
        }
        #endregion

        public override Domain.Models.Lanche Get(int? id)
        {
            return _ctx.Lanches
            .Include(l => l.LanchesIngredientes)
            .ThenInclude(li => li.Ingrediente).FirstOrDefault(l => l.Id == id);
        }

        public IEnumerable<Domain.Models.Lanche> GetAllEager()
        {
            return _ctx.Lanches
                .Include(l => l.LanchesIngredientes)
                .ThenInclude(li => li.Ingrediente);
        }
    }
}
