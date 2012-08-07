using System.Web.Mvc;

namespace System.Web.Mvc
{
    public static class HtmlHelperExtension
    {
        public static string EncodeDoubleQuotes(this HtmlHelper html, string value)
        {
            return value.Replace(@"""", @"\""");
        }
    }
}
