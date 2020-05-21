using Lanche.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lanche.Infra.Data.Mappings
{
    public class LancheIngredienteMap : IEntityTypeConfiguration<LancheIngrediente>
    {
        public void Configure(EntityTypeBuilder<LancheIngrediente> lancheingrediente)
        {
            lancheingrediente.ToTable("LanchesIngredientes");

            lancheingrediente.HasKey(li => li.Id);

            lancheingrediente
                .HasOne(li => li.Lanche)
                .WithMany(l => l.LanchesIngredientes)
                .HasForeignKey(li => li.LancheId)
                .OnDelete(DeleteBehavior.Restrict);

            lancheingrediente
                .HasOne(li => li.Ingrediente)
                .WithMany(i => i.LanchesIngredientes)
                .HasForeignKey(li => li.IngredienteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
