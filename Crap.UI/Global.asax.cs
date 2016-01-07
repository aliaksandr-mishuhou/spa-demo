using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;
using Crap.UI.App_Start;

namespace Crap.UI
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            AutofacConfig.Initialize(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configuration.EnsureInitialized();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.Configure();
        }
    }
}
