using System;

namespace Ecx.Infra.CrossCutting.IoC
{
    public class Resolver
    {
        private readonly static IResolver _instance;

        private Resolver() { }

        static Resolver()
        {

            var objectHandler = Activator.CreateInstance("Ecx.Infra.CrossCutting.IoC", "Ecx.Infra.CrossCutting.IoC.NinjectResolver");
            if (objectHandler == null)
            {
                throw new TypeLoadException("ResolverNInject não localizado");
            }

            _instance = objectHandler.Unwrap() as IResolver;
        }

        public static IResolver Current
        {
            get
            {
                return _instance;
            }
        }
    }
}
