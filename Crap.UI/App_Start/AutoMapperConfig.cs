using AutoMapper;
using Crap.UI.ViewModels;

namespace Crap.UI.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(c => c.AddProfile<DomainToViewModelMappings>());
        }
    }
}