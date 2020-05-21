using Lanche.Domain.Core.Models;

namespace Lanche.Domain.Models
{
    public class LancheIngrediente : Entity
    {
        public int LancheId { get; set; }
        public virtual Lanche Lanche { get; set; }

        public int IngredienteId { get; set; }
        public virtual Ingrediente Ingrediente { get; set; }

        public int QtdIngrediente { get; set; }
    }
}
