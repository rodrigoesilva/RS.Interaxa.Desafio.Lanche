using AutoMapper;
using Lanche.Application.ViewModels;
using Lanche.Domain.Models;

namespace Lanche.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Ingrediente, IngredienteVM>();
            CreateMap<Domain.Models.Lanche, LancheVM>();
            CreateMap<LancheIngrediente, LancheIngredienteVM>();
            CreateMap<Promocao, PromocaoVM>();
        }
    }
}
