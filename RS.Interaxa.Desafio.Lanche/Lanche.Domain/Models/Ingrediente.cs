using Lanche.Domain.Core.Models;
using System.Collections.Generic;

namespace Lanche.Domain.Models
{
    public class Ingrediente : Entity
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public virtual ICollection<LancheIngrediente> LanchesIngredientes { get; set; }

        public Ingrediente()
        {
            LanchesIngredientes = new List<LancheIngrediente>();
        }

    }
}
