using System.Web;
using WURFL;
using WURFL.Aspnet.Extensions.Config;

namespace web.Core
{
    static class WurflManagerApplicationExtension
    {
        private const string WurflManagerCacheKey = @"__WurflManager";

        public static void ConfigureWurflManager(this HttpApplicationState application)
        {
            var configurer = new ApplicationConfigurer();
            var manager = WURFLManagerBuilder.Build(configurer);
            application[WurflManagerCacheKey] = manager;
        }

        public static IWURFLManager GetWurflManager(this HttpApplicationStateBase application)
        {
            return application[WurflManagerCacheKey] as IWURFLManager;
        }
    }
}