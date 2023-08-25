using API;
using AutoMapper;

namespace Tests
{
    internal static class AutoMapper
    {
        public static IMapper GetMapper()
        {
            var mappingProfile = new AutoMapperProfile();
            var configuration = new MapperConfiguration(config => config.AddProfile(mappingProfile));

            return new Mapper(configuration);
        }
    }
}
