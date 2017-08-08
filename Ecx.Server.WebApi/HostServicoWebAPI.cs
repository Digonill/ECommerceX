using Ecx.ConfigDependencia;
using EcX.Host;
using System;
using Topshelf;

namespace EcX.Server.WebApi
{
    public class HostServicoWebAPI : ServiceControl
    {
        protected IDisposable _HostAPi = null;
        private readonly IHostFactory _HostFactory;

        public HostServicoWebAPI(IHostFactory host_)
        {
            _HostFactory = host_;
        }

        public bool Start(HostControl hostControl)
        {
            ResolverConfig.Configure();

            _HostAPi = _HostFactory.Create();

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            //Finaliza o Host
            _HostAPi?.Dispose();

            return true;
        }
    }
}
