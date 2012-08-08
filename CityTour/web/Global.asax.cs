using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using web.Areas;
using WURFL;
using WURFL.Aspnet.Extensions.Config;

namespace web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute(@"{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                @"Default", // Route name
                @"{controller}/{action}/{id}", // URL with parameters
                new { controller = @"Home", action = @"Index", id = UrlParameter.Optional }, // Parameter defaults
                new string[] { @"web.Controllers" } // Default Namespace.
            ).DataTokens[@"UseNamespaceFallback"] = false;
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            Application.ConfigureWurflManager();

            CityTourContext.Initialize();
        }
    }

    static class WurflManagerApplicationExtension
    {
        private const string WurflManagerCacheKey = @"__WurflManager";

        public static void ConfigureWurflManager(this HttpApplicationState application)
        {
            var configurer = new ApplicationConfigurer();
            var manager = WURFLManagerBuilder.Build(configurer);
            application[WurflManagerCacheKey] = manager;
        }

        public static IWURFLManager GetWurflManager(this HttpApplicationState application)
        {
            return application[WurflManagerCacheKey] as IWURFLManager;
        }

        public static bool IsMobile(this HttpContext httpContext)
        {
            var manager = httpContext.Application.GetWurflManager();

            if (manager != null)
            {
                var device = manager.GetDeviceForRequest(httpContext.Request.UserAgent, WURFL.MatchMode.Performance);

                bool isMobile = device.GetCapability(@"is_wireless_device") == @"true";
                bool supportsJavascript = device.GetCapability(@"ajax_support_javascript") == @"true";

                return isMobile && supportsJavascript;
            }

            return false;
        }
    }
}
