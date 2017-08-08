using System;

namespace Ecx.Infra.CrossCutting.IoC
{
    public interface IResolver
    {
        void Register<TType>(Type implementation);

        void RegisterSingleton<TType>(Type implementation);
        
        void Register<TType>(string name, Type implementation);
        void Register(Type type, Type implementation);
        TType Resolve<TType>();
        TType Resolve<TType>(params IConstrutorParameter[] construtorParameters);
        TType Resolve<TType>(string name);
        TType Resolve<TType>(string name, params IConstrutorParameter[] construtorParameters);
        object Resolve(Type type);
        object Container { get; }
        bool CanResolve(Type type);
    }
}
