using Microsoft.Owin.Hosting;
using System;
using System.Configuration;


namespace EcX.Server.WebApi
{
    public class HostConfigFactory : Host.IHostFactory
    {
        public IDisposable Create()
        {
            var startOptions = new StartOptions();
            startOptions.Urls.Add(ConfigurationManager.AppSettings["urlWebApi"]);

            return WebApp.Start<AppBuilder>(startOptions);
        }
    }
}
