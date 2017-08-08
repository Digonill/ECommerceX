using Ecx.Aplicacao.Cliente;
using Ecx.Aplicacao.Usuario;
using Ecx.Infra.CrossCutting.IoC;
using EcX.Aplicacao.Cliente;
using EcX.Aplicacao.Produto;
using EcX.Dominio.Interface;
using EcX.Dominio.Repositorio;
using EcX.Dominio.Servico;
using EcX.Infra.Data.Contexto;
using EcX.Infra.Data.Repositorio;

namespace Ecx.ConfigDependencia
{
    public static class ResolverConfig
    {
        private static object _locker = new object();
        private static bool _loaded = false;

        public static IResolver Configure()
        {
            lock (_locker)
            {
                if (_loaded)
                {
                    return Resolver.Current;
                }
            }

            ForceLocalCopy();

            // 
            Resolver.Current.Register<IDatabaseContexto>(typeof(EcXDBContexto));

            //Cliente
            Resolver.Current.Register<IRepositorioCliente>(typeof(ClienteRepositorio));
            Resolver.Current.Register<IClienteServicoDominio>(typeof(ClienteServicoDominio));
            Resolver.Current.Register<IClienteServicoApi>(typeof(ClienteServicoApi));

            //Produto
            Resolver.Current.Register<IRepositorioProduto>(typeof(ProdutoRepositorio));
            Resolver.Current.Register<IProdutoServicoDominio>(typeof(ProdutoServicoDominio));
            Resolver.Current.Register<IProdutoServicoApi>(typeof(ProdutoServicoApi));

            //Usuario
            Resolver.Current.Register<IRepositorioUsuario>(typeof(UsuarioRepositorio));
            Resolver.Current.Register<IUsuarioServicoDominio>(typeof(UsuarioServicoDominio));
            Resolver.Current.Register<IUsuarioServicoApi>(typeof(UsuarioServicoApi));


            _loaded = true;

            return Resolver.Current;

        }
        private static void ForceLocalCopy()
        {
            var t1 = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }
    }
}
