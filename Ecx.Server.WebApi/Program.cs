using Topshelf;

namespace EcX.Server.WebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.UseAssemblyInfoForServiceInfo();
                x.RunAsLocalSystem();
                x.Service(() => new HostServicoWebAPI(new HostConfigFactory()));
                x.SetDescription("Serviço de hospedagem do servidor Ecx.Server.WebAPI");
                x.SetDisplayName("Ecx.Server.WebAPI");
                x.SetServiceName("Ecx.Server.WebAPI");
                x.StartAutomatically();
            });
        }
    }
}
