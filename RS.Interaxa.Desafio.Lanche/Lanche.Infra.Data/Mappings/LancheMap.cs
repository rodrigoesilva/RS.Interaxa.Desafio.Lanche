using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lanche.Infra.Data.Mappings
{
    public class LancheMap : IEntityTypeConfiguration<Domain.Models.Lanche>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Lanche> builder)
        {
            builder.ToTable("Lanches");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
               .HasColumnType("varchar(200)")
               .IsRequired();

            builder.Property(p => p.Preco)
               .HasColumnType("decimal(5,2)")
               .IsRequired();
        }
    }
}
