using System.Web.Mvc;

namespace web.Areas.Api
{
    public class ApiAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return @"Api";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                @"ApiDefault",
                @"Api/{controller}/{action}"
            );
        }
    }
}
