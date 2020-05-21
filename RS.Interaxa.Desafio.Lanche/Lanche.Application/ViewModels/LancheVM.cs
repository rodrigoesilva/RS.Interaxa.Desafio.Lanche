using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lanche.Application.ViewModels
{
    public class LancheVM
    {
        [Display(Name = "Código Interno")]
        public int Id { get; set; }

        [Display(Name = "Data de Cadastro")]
        public string DataCadastro { get; set; }

        [Display(Name = "Lanche"), Required, MaxLength(50)]
        public string Nome { get; set; }

        [Display(Name = "Preço R$"), Required]
        public string Preco { get; set; }

        public string Total { get; set; }

        public ICollection<LancheIngredienteVM> Ingredientes { get; set; }

        public LancheVM()
        {
            Ingredientes = new List<LancheIngredienteVM>();
        }
    }
}
