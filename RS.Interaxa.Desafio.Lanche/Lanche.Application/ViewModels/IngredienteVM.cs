using System.ComponentModel.DataAnnotations;

namespace Lanche.Application.ViewModels
{
    public class IngredienteVM
    {
        [Display(Name = "Código Interno")]
        public int Id { get; set; }

        [Display(Name = "Data de Cadastro")]
        public string DataCadastro { get; set; }

        [Display(Name = "Ingrediente"), Required, MaxLength(50)]
        public string Nome { get; set; }

        [Display(Name = "Preço R$"), Required]
        public string Preco { get; set; }
    }
}
