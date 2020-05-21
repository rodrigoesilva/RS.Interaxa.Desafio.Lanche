using System.ComponentModel.DataAnnotations;

namespace Lanche.Application.ViewModels
{
    public class LancheIngredienteVM
    {
        public int IdIngrediente { get; set; }
        public string NomeIngrediente { get; set; }
        public int QtdIngrediente { get; set; }
    }
}
