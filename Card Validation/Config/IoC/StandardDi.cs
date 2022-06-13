using Card.Validation.Core.Attributes;
using Card.Validation.Core.Config.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Unity;

namespace Card.Validation.Web.App.Config.IoC
{
    public static class StandardDi
    {
        private static IUnityContainer _container;

        public static IUnityContainer Container
        {
            get
            {
                if (_container == null)                  
                    InitialiseContainer(IocDomain.Card);  

                return _container;                    
            }
        }

        public static void InitialiseContainer(IocDomain domainName)
        {
            if (_container != null)
                return;

            _container = new UnityContainer();

            var domain = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t =>  Attribute.IsDefined(t, typeof(IocDomainAttribute)))
                .FirstOrDefault(
                    a => (a.GetCustomAttribute<IocDomainAttribute>().Name ?? a.Name) == domainName.ToString()
                );

            if (domain == null)
                throw new ApplicationException("Not configured in assembly");

            var initialiseMethod = domain.GetMethod("Initialise", BindingFlags.Public | BindingFlags.Static);

            if (initialiseMethod == null)
                throw new ApplicationException("Method Initialise does not exist");

            initialiseMethod.Invoke(null, new object[] { _container });
        }
    }
}