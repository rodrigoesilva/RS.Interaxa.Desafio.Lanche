using Lanche.Domain.Core.Models;
using System.Collections.Generic;

namespace Lanche.Domain.Models
{
    public class Lanche : Entity
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public virtual ICollection<LancheIngrediente> LanchesIngredientes { get; set; }

        public Lanche()
        {
            LanchesIngredientes = new List<LancheIngrediente>();
        }
    }
}
