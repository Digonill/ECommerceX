using System;

namespace EcX.Dominio.Interface
{
    public interface IEntidade
    {

    }
    public interface IEntidade<TIdentificador> : IEntidade, IEquatable<IEntidade<TIdentificador>>
    {
        TIdentificador ID { get; set; }
    }
}
