using Lanche.Domain.Interfaces.Repositories;
using Lanche.Domain.Models;
using Lanche.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Lanche.Infra.Data.Repository
{
    public class PromocaoRepository : Repository<Promocao>, IPromocaoRepository
    {
        public PromocaoRepository(LancheContext ctx) : base(ctx)
        { }

        #region Métodos utilizando Procedures
        public IEnumerable<Promocao> SP_ListAll()
        {
            return _ctx.Promocoes
                 .FromSql("sp_Promocoes_ListAll");
        }

        public Promocao SP_GetById(int? id)
        {

            return _ctx.Promocoes
                 .FromSql("sp_Promocoes_ById @p0", id).FirstOrDefault();
        }
        #endregion

    }
}
