namespace Ecx.Infra.CrossCutting.IoC
{
    public static class ConstrutorArgumentHelper
    {
        public static Ninject.Parameters.ConstructorArgument[] ConvertToNInjectConstrutorArguments(this IConstrutorParameter[] construtorParameters)
        {
            var convertedConstrutorArguments = new Ninject.Parameters.ConstructorArgument[construtorParameters.Length];
            for (int i = 0; i < construtorParameters.Length; i++)
            {
                convertedConstrutorArguments[i] = new Ninject.Parameters.ConstructorArgument(construtorParameters[i].Name, construtorParameters[i].Value);
            }

            return convertedConstrutorArguments;
        }
    }
}
