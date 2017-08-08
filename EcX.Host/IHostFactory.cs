using System;

namespace EcX.Host
{
    public interface IHostFactory
    {
        IDisposable Create();
    }
}
