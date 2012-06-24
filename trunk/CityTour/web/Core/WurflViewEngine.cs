using System.Web;
using System.Web.Mvc;

namespace web.Core
{
    public class WurflViewEngine : RazorViewEngine
    {
        public WurflViewEngine()
            : base()
        {
            OverridePaths(this.AreaMasterLocationFormats);
            OverridePaths(this.AreaPartialViewLocationFormats);
            OverridePaths(this.AreaViewLocationFormats);
            OverridePaths(this.MasterLocationFormats);
            OverridePaths(this.PartialViewLocationFormats);
            OverridePaths(this.ViewLocationFormats);
        }

        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            if (IsSmartphone(controllerContext.HttpContext))
            {
                return base.FileExists(controllerContext, virtualPath);
            }

            return false;
        }

        private void OverridePaths(string[] paths)
        {
            for (int i = 0; i < paths.Length; ++i)
            {
                var path = paths[i];
                path = path.Replace(@"Views/", @"ViewsSmartphone/");
                paths[i] = path;
            }
        }

        private bool IsSmartphone(HttpContextBase httpContext)
        {
            var manager = httpContext.Application.GetWurflManager();

            if (manager != null)
            {
                var device = manager.GetDeviceForRequest(httpContext.Request.UserAgent, WURFL.MatchMode.Performance);

                bool isMobile = device.GetCapability(@"is_wireless_device") == "true";
                bool supportsJavascript = device.GetCapability(@"ajax_support_javascript") == "true";

                return isMobile && supportsJavascript;
            }

            return false;
        }
    }
}
