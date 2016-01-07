using AutoMapper;
using Crap.Data.Entities;

namespace Crap.UI.ViewModels
{
    public class DomainToViewModelMappings : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<Category, CategoryViewModel>();
        }
    }
}