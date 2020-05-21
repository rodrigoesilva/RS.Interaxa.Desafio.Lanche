using Lanche.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace Lanche.Infra.Data.Migrations
{
    [DbContext(typeof(LancheContext))]
    public class LancheContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationCore.Domain.Entities.Ingrediente", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<DateTime>("DataCadastro");

                b.Property<string>("Nome")
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                b.Property<decimal>("Preco")
                    .HasColumnType("decimal(5,2)");

                b.HasKey("Id");

                b.ToTable("Ingredientes");
            });

            modelBuilder.Entity("ApplicationCore.Domain.Entities.Lanche", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<DateTime>("DataCadastro");

                b.Property<string>("Nome")
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                b.Property<decimal>("Preco")
                    .HasColumnType("decimal(5,2)");

                b.HasKey("Id");

                b.ToTable("Lanches");
            });

            modelBuilder.Entity("ApplicationCore.Domain.Entities.LancheIngrediente", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<DateTime>("DataCadastro");

                b.Property<int>("IngredienteId");

                b.Property<int>("LancheId");

                b.Property<int>("QtdIngrediente");

                b.HasKey("Id");

                b.HasIndex("IngredienteId");

                b.HasIndex("LancheId");

                b.ToTable("LanchesIngredientes");
            });

            modelBuilder.Entity("ApplicationCore.Domain.Entities.LancheIngrediente", b =>
            {
                b.HasOne("ApplicationCore.Domain.Entities.Ingrediente", "Ingrediente")
                    .WithMany("LanchesIngredientes")
                    .HasForeignKey("IngredienteId")
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne("ApplicationCore.Domain.Entities.Lanche", "Lanche")
                    .WithMany("LanchesIngredientes")
                    .HasForeignKey("LancheId")
                    .OnDelete(DeleteBehavior.Restrict);
            });
#pragma warning restore 612, 618
        }
    }
}

