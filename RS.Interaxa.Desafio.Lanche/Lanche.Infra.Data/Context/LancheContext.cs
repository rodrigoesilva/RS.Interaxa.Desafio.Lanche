using Microsoft.EntityFrameworkCore;
using Lanche.Domain.Models;

namespace Lanche.Infra.Data.Context
{
    public class LancheContext : DbContext
    {
        public LancheContext(DbContextOptions<LancheContext> options) : base(options)
        { }

        public DbSet<Domain.Models.Lanche> Lanches { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<LancheIngrediente> LanchesIngredientes { get; set; }

        public DbSet<Promocao> Promocoes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new Mappings.LancheMap());
            builder.ApplyConfiguration(new Mappings.IngredienteMap());
            builder.ApplyConfiguration(new Mappings.LancheIngredienteMap());
            builder.ApplyConfiguration(new Mappings.PromocaoMap());
        }
    }
}
