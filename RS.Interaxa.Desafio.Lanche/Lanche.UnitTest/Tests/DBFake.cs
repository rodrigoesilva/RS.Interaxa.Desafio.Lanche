using Lanche.Domain.Models;
using System.Collections.Generic;

namespace Lanche.UnitTest.Tests
{
    public static class DBFake
    {
        public static List<Domain.Models.Lanche> Lanches { get; set; } = new List<Domain.Models.Lanche>();
        public static List<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();
        public static List<LancheIngrediente> LanchesIngredientes { get; set; } = new List<LancheIngrediente>();

        public static void CarregarBase()
        {
            var Alface = new Ingrediente { Id = 1, Nome = "Alface", Preco = 0.40m };
            var Bacon = new Ingrediente { Id = 2, Nome = "Bacon", Preco = 2.00m };
            var Hamburguer = new Ingrediente { Id = 3, Nome = "Hambúrguer de carne", Preco = 3.00m };
            var Ovo = new Ingrediente { Id = 4, Nome = "Ovo", Preco = 0.80m };
            var Queijo = new Ingrediente { Id = 5, Nome = "Queijo", Preco = 1.50m };

            Ingredientes.AddRange(new List<Ingrediente> {
                Alface,
                Bacon,
                Hamburguer,
                Ovo,
                Queijo
            });
        }
    }
}
