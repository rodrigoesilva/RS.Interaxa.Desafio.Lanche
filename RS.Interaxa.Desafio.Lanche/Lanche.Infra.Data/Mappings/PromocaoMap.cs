using Lanche.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lanche.Infra.Data.Mappings
{
    public class PromocaoMap : IEntityTypeConfiguration<Promocao>
    {
        public void Configure(EntityTypeBuilder<Promocao> builder)
        {
            builder.ToTable("Promocoes");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
               .HasColumnType("varchar(500)")
               .IsRequired();

            builder.Property(p => p.Descricao)
              .HasColumnType("varchar(500)")
              .IsRequired();
        }
    }
}
