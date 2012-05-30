using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Runtime.Serialization;

namespace web.Views.DataContracts
{
    public class DataContractJsonResult : JsonResult
    {
        public DataContractJsonResult(object data)
        {
            Data = data;
        }

        public DataContractJsonResult()
        {
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("This request has been blocked because sensitive information could be disclosed to third party web sites when this is used in a GET request. To allow GET requests, set JsonRequestBehavior to AllowGet.");
            }

            HttpResponseBase response = context.HttpContext.Response;

            if (!string.IsNullOrEmpty(ContentType))
            {
                response.ContentType = ContentType;
            }
            else
            {
                response.ContentType = "application/json";
            }
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
            if (Data != null)
            {                
                using (var ms = new MemoryStream())
                {
                    var serializer = new DataContractJsonSerializer(Data.GetType());
                    serializer.WriteObject(ms, Data);
                    string json = Encoding.UTF8.GetString(ms.ToArray());
                    response.Write(json);
                }
            }
        }
    }
}