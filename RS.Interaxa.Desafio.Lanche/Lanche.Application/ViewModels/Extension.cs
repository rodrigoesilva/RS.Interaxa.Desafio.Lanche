using Lanche.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lanche.Application.ViewModels
{
    public static class Extension
    {
        #region IngredienteVM
        public static IEnumerable<IngredienteVM> ToViewsModels(this IEnumerable<Ingrediente> ingredientes)
        {
            return ingredientes.Select(p => new IngredienteVM
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco.ToString(),
                DataCadastro = p.DataCadastro.ToString("dd/MM/yyyy")
            });
        }

        public static Ingrediente ToModel(this IngredienteVM ingredienteVM)
        {
            return new Ingrediente
            {
                Id = ingredienteVM.Id,
                Nome = ingredienteVM.Nome,
                Preco = Convert.ToDecimal(ingredienteVM.Preco.Replace('.', ',')),
                DataCadastro = string.IsNullOrEmpty(ingredienteVM.DataCadastro) ? DateTime.Now : DateTime.Parse(ingredienteVM.DataCadastro)
            };
        }

        public static IngredienteVM ToViewModel(this Ingrediente ingrediente)
        {
            return new IngredienteVM
            {
                Id = ingrediente.Id,
                Nome = ingrediente.Nome,
                Preco = ingrediente.Preco.ToString(),
                DataCadastro = ingrediente.DataCadastro.ToString("dd/MM/yyyy")
            };
        }
        #endregion

        #region IngredienteLancheVM
        private static IEnumerable<LancheIngredienteVM> Ingredientes(IEnumerable<LancheIngrediente> lanchesIngredientes)
        {
            return lanchesIngredientes.Select(i => new LancheIngredienteVM
            {
                IdIngrediente = i.IngredienteId,
                NomeIngrediente = i.Ingrediente.Nome,
                QtdIngrediente = i.QtdIngrediente
            });
        }

        private static IEnumerable<LancheIngrediente> LanchesIngredientes(int lancheId, ICollection<LancheIngredienteVM> ingredientes)
        {
            return ingredientes.Select(li => new LancheIngrediente
            {
                LancheId = lancheId,
                IngredienteId = li.IdIngrediente,
                QtdIngrediente = li.QtdIngrediente,
            });
        }
        #endregion

        #region LancheVM
        public static IEnumerable<LancheVM> ToViewsModels(this IEnumerable<Domain.Models.Lanche> lanches)
        {
            return lanches.Select(p => new LancheVM
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco.ToString(),
                DataCadastro = p.DataCadastro.ToString("dd/MM/yyyy"),
                Ingredientes = Ingredientes(p.LanchesIngredientes).ToList()
            });
        }

        public static Domain.Models.Lanche ToModel(this LancheVM lancheVM)
        {
            return new Domain.Models.Lanche
            {
                Id = lancheVM.Id,
                Nome = lancheVM.Nome,
                Preco = Convert.ToDecimal(lancheVM.Preco.Replace('.', ',')),
                DataCadastro = string.IsNullOrEmpty(lancheVM.DataCadastro) ? DateTime.Now : DateTime.Parse(lancheVM.DataCadastro),
                LanchesIngredientes = LanchesIngredientes(lancheVM.Id, lancheVM.Ingredientes).ToList()
            };
        }

        public static LancheVM ToViewModel(this Domain.Models.Lanche lanche)
        {
            return new LancheVM
            {
                Id = lanche.Id,
                Nome = lanche.Nome,
                Preco = lanche.Preco.ToString(),
                DataCadastro = lanche.DataCadastro.ToString("dd/MM/yyyy"),
                Ingredientes = Ingredientes(lanche.LanchesIngredientes).ToList()
            };
        }
        #endregion

        #region PromocaoVM
        public static IEnumerable<PromocaoVM> ToViewsModels(this IEnumerable<Promocao> promocoes)
        {
            return promocoes.Select(p => new PromocaoVM
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                DataCadastro = p.DataCadastro.ToString("dd/MM/yyyy")
            });
        }

        public static Promocao ToModel(this PromocaoVM promocaoVM)
        {
            return new Promocao
            {
                Id = promocaoVM.Id,
                Nome = promocaoVM.Nome,
                Descricao = promocaoVM.Descricao,
                DataCadastro = string.IsNullOrEmpty(promocaoVM.DataCadastro) ? DateTime.Now : DateTime.Parse(promocaoVM.DataCadastro)
            };
        }

        public static PromocaoVM ToViewModel(this Promocao promocao)
        {
            return new PromocaoVM
            {
                Id = promocao.Id,
                Nome = promocao.Nome,
                Descricao = promocao.Descricao,
                DataCadastro = promocao.DataCadastro.ToString("dd/MM/yyyy")
            };
        }
        #endregion

    }
}
