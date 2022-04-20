using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing;

namespace Bookstore_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            config.MapHttpAttributeRoutes();

            /*config.Routes.MapHttpRoute("DefaultApiGet",
                           "api/{controller}",
                           new { action = "Get" },
                           new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) });*/

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
