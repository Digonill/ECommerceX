using Ecx.ConfigDependencia;
using Newtonsoft.Json;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace EcX.Server.WebApi
{
    public class AppBuilder
    {
        public void Configuration(IAppBuilder app)
        {
            Dependencies.ForceCopyLocal();

            HttpConfiguration configHTTP = new HttpConfiguration();

            configHTTP.Services.Replace(typeof(IExceptionHandler), new ExceptionHandler());

            configHTTP.Formatters.Add(configHTTP.Formatters.JsonFormatter);
            configHTTP.Formatters.Remove(configHTTP.Formatters.XmlFormatter);
            configHTTP.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            configHTTP.Formatters.JsonFormatter.SerializerSettings.TypeNameHandling = TypeNameHandling.Objects;
            configHTTP.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            //TypeAdapterConfig.Configure();

            app.UseNinjectMiddleware(() => { return ResolverConfig.Configure().Container as IKernel; });
            app.UseNinjectWebApi(configHTTP);

            //configHTTP.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //     routeTemplate: "api/{controller}",
            //      defaults: new { id = RouteParameter.Optional });
            configHTTP.Routes.MapHttpRoute("DefaultApi", "api/{controller}");

            app.UseErrorPage(new Microsoft.Owin.Diagnostics.ErrorPageOptions()
            {
                ShowCookies = true,
                ShowEnvironment = true,
                ShowExceptionDetails = true,
                ShowHeaders = true,
                ShowQuery = true,
                ShowSourceCode = true
            });

            configHTTP.MapHttpAttributeRoutes();

            configHTTP.EnsureInitialized();
        }
    }
}
