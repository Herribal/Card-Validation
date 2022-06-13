using AutoMapper;
using Card.Validation.Web.Core;
using System.Configuration;
using System.Reflection;

namespace Card.Validation.Core.Config
{
    public static class AutoMapperConfig
    {
        public static IMapper CreateCustomMaps()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(Assembly.GetAssembly(typeof(CoreSeeker)));
            });

            return config.CreateMapper();
        }
    }
}