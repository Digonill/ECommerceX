namespace Ecx.Infra.CrossCutting.IoC

{
    using Ninject;
    using System;
    using System.Collections.Generic;



    public class NinjectResolver : IResolver
    {
        private IKernel _kernel;

        public object Container
        {
            get
            {
                return _kernel;
            }
        }

        public NinjectResolver()
        {
            _kernel = new StandardKernel(
                new NinjectSettings { LoadExtensions = true });
        }

        public void RegisterSingleton<TType>(Type implementation)
        {
            _kernel.Bind<TType>().To(implementation).InSingletonScope();
        }

        public void Register<TType>(Type implementation)
        {
            _kernel.Bind<TType>().To(implementation);
        }
        public void Register<TType>(string name, Type implementation)
        {
            _kernel.Bind<TType>().To(implementation).Named(name);

        }
        public void Register(Type type, Type implementation)
        {
            _kernel.Bind(type).To(implementation);
        }
        public IEnumerable<TType> ResolveAll<TType>()
        {
            return _kernel.GetAll<TType>();
        }

        public TType Resolve<TType>()
        {
            return _kernel.Get<TType>();
        }

        public TType Resolve<TType>(string name)
        {
            return _kernel.Get<TType>(name, null);
        }
        public TType Resolve<TType>(params IConstrutorParameter[] construtorParameters)
        {
            return _kernel.Get<TType>(construtorParameters.ConvertToNInjectConstrutorArguments());
        }
        public TType Resolve<TType>(string name, params IConstrutorParameter[] construtorParameters)
        {
            return _kernel.Get<TType>(name, construtorParameters.ConvertToNInjectConstrutorArguments());
        }
        public object Resolve(Type type)
        {
            return _kernel.Get(type);
        }
        public bool CanResolve(Type type)
        {
            return (bool)_kernel.CanResolve(type);
        }
    }
}
