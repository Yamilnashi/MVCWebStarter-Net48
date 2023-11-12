using System;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebMvc.App_Start;

namespace WebMvc
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            MvcHandler.DisableMvcResponseHeader = true;
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();

            Server.ClearError();

            if (exception is HttpException httpException)
            {
                switch (httpException.GetHttpCode())
                {
                    case (int)HttpStatusCode.NotFound:
                        string originalUrl = HttpContext.Current.Request.Url.ToString();
                        Response.Redirect($"~/Error/NotFound?requestedUrl={HttpUtility.UrlEncode(originalUrl)}");
                        break;
                    case (int)HttpStatusCode.InternalServerError:
                        Response.Redirect("~/Error/InternalServer");
                        break;
                    case (int)HttpStatusCode.Forbidden:
                        Response.Redirect("~/Error/Forbidden");
                        break;
                    case (int)HttpStatusCode.Unauthorized:
                        Response.Redirect("~/Error/Unauthorized");
                        break;
                    default:
                        Response.Redirect("~/Error/InternalServer");
                        break;
                }
            } else
            {
                Response.Redirect("~/Error/GenericError");
            }

            
        }
    }
}
