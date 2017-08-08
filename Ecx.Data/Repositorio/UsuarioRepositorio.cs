namespace EcX.Infra.Data.Repositorio
{
    using Dominio.Entidade;
    using Dominio.Interface;
    using Dominio.Repositorio;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class UsuarioRepositorio : RepositorioBase<UsuarioEntidade, Guid>, IRepositorioUsuario
    {
        public UsuarioRepositorio(IDatabaseContexto contexto) : base(contexto)
        {

        }

        public bool VerificarAdminSistema(Guid ID)
        {
            AdministradorEntidade user = DbSet.OfType<AdministradorEntidade>()
                .Where(_ => _.ID == ID).SingleOrDefault();

            return user != null;
        }
    }
}
