using System.Web.Mvc;
using System.Web.Routing;

namespace Card.Validation.Web.App.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        { }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }
    }
}