using AutoMapper;
using PlayerActivity.BusinessLogic.Models;
using PlayerActivity.Contracts.Models;

namespace PlayerActivity.BusinessLogic.Infrastructure
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