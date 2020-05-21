using System.ComponentModel.DataAnnotations;

namespace Lanche.Application.ViewModels
{
    public class PromocaoVM
    {
        [Display(Name = "Código Interno")]
        public int Id { get; set; }

        [Display(Name = "Data de Cadastro")]
        public string DataCadastro { get; set; }

        [Display(Name = "Promoção"), Required, MaxLength(500)]
        public string Nome { get; set; }

        [Display(Name = "Descrição"), Required, MaxLength(500)]
        public string Descricao { get; set; }
    }
}
