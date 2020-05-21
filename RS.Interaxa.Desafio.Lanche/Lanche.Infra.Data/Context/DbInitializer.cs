using Lanche.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Lanche.Infra.Data.Context
{
    public static class DbInitializer
    {
        public static void Initialize(LancheContext context)
        {
            if (context.Ingredientes.Any())
            {
                return;
            }

            #region Ingredientes

            var Alface = new Ingrediente { Nome = "Alface", Preco = 0.40m };
            var Bacon = new Ingrediente { Nome = "Bacon", Preco = 2.00m };
            var Hamburguer = new Ingrediente { Nome = "Hambúrguer de carne", Preco = 3.00m };
            var Ovo = new Ingrediente { Nome = "Ovo", Preco = 0.80m };
            var Queijo = new Ingrediente { Nome = "Queijo", Preco = 1.50m };

            var ingredientes = new List<Ingrediente> {
                Alface, Bacon, Hamburguer, Ovo, Queijo
            };

            context.Ingredientes.AddRange(ingredientes);

            #endregion

            #region Lanches

            var xSalada = new Domain.Models.Lanche { Nome = "X-Salada", Preco = 10.99m };
            var xBacon = new Domain.Models.Lanche { Nome = "X-Bacon", Preco = 12.99m };

            var lanches = new List<Domain.Models.Lanche> {
                xSalada, xBacon
            };

            context.Lanches.AddRange(lanches);

            #endregion

            #region LanchesIngredientes

            context.LanchesIngredientes.AddRange(new List<LancheIngrediente> {
                new LancheIngrediente{ Ingrediente = Alface, Lanche = xSalada, QtdIngrediente = 2 },
                new LancheIngrediente{ Ingrediente = Ovo, Lanche = xSalada, QtdIngrediente = 2 },
                new LancheIngrediente{ Ingrediente = Queijo, Lanche = xSalada, QtdIngrediente = 2 },
                new LancheIngrediente{ Ingrediente = Hamburguer, Lanche = xSalada, QtdIngrediente = 2 },
                new LancheIngrediente{ Ingrediente = Bacon, Lanche = xBacon, QtdIngrediente = 2 },
                new LancheIngrediente{ Ingrediente = Queijo, Lanche = xBacon, QtdIngrediente = 2 },
                new LancheIngrediente{ Ingrediente = Hamburguer, Lanche = xBacon, QtdIngrediente = 2 }
            });

            #endregion

            context.SaveChanges();
        }
    }
}
