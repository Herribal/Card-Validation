using Card.Validation.Core.Attributes;
using Card.Validation.Core.Config;
using Card.Validation.Web.App.DataAccess.RepositoryUow.DB;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace Card.Validation.Web.App.Config.IoC.Domain
{
    [IocDomain]
    public static class Card
    {
        public static void Initialise(IUnityContainer container)
        {
            container.RegisterType<IDBRepositoryUow, DBRepositoryUow>(new TransientLifetimeManager(),
                new InjectionConstructor(AppConfig.DatabaseConnection));

            container.RegisterInstance(AutoMapperConfig.CreateCustomMaps());
        }
    }
}