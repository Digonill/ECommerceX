using EcX.Dominio.Entidade;
using System;
using System.Data.Entity;
using System.Linq;

namespace EcX.Infra.Data.Contexto
{
    public sealed class DBSetup : DropCreateDatabaseIfModelChanges<EcXDBContexto>
    {

        protected override void Seed(EcXDBContexto context)
        {

            if (context.GetOrSetDbSet<AdministradorEntidade>().Where(a => a.Login == "Admin@Admin.com.br").FirstOrDefault() == null)
            {
                context.Add<AdministradorEntidade>(new AdministradorEntidade()
                {
                    ID = Guid.NewGuid(),
                    Login = "Admin@Admin.com.br",
                    Senha = "Admin",
                    Nome = "Administrador do Sistema"
                });
            }

            context.Add<ProdutoEntidade>(new ProdutoEntidade()
            {
                ID = Guid.NewGuid(),
                Nome = "TV 32'",
                Descricao = "Televisor Led Samsung",
                Valor = 1000

            });

            context.Add<ProdutoEntidade>(new ProdutoEntidade()
            {
                ID = Guid.NewGuid(),
                Nome = "Iphone 6 32GB",
                Descricao = "Celular da Apple",
                Valor = 3500

            });

            context.SaveChanges();

            base.Seed(context);
        }

    }
}
