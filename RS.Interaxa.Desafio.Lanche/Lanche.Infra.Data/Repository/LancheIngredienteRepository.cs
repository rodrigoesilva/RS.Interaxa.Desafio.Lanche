using Lanche.Domain.Interfaces.Repositories;
using Lanche.Domain.Models;
using Lanche.Infra.Data.Context;

namespace Lanche.Infra.Data.Repository
{
    public class LancheIngredienteRepository : Repository<LancheIngrediente>, ILancheIngredienteRepository
    {
        public LancheIngredienteRepository(LancheContext ctx) : base(ctx)
        { }
    }
}
