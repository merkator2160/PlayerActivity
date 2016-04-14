using AutoMapper;
using BusinessLogic.Models;
using Contracts.Models;

namespace BusinessLogic.Infrastructure
{
    internal static class AutoMapperConfig
    {
        // FUNCTIONS //////////////////////////////////////////////////////////////////////////////
        public static IMapper GetConfiguredMapper()
        {
            return new MapperConfiguration(RegisterMappings).CreateMapper();
        }
        private static void RegisterMappings(IMapperConfiguration cfg)
        {
            cfg.CreateMap<ActivityDto, Activity>();
        }
    }
}