using Card.Validation.Core.Config.IoC;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using AppDi = Card.Validation.Web.App.Config.IoC.StandardDi;

namespace Card.Validation.Web.App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AppDi.InitialiseContainer(IocDomain.Card);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
