using Card.Validation.Web.Core.Integration.Connector.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace Card.Validation.Web.Core.Config.IoC.Domain
{
    public static class CardConfiguration
    {
        public static void Initialise(IUnityContainer container)
        {
            container.RegisterType<ICard, Card>(new TransientLifetimeManager(),
                new InjectionConstructor(AppConfig.DatabaseConnection));
        }
    }
}
