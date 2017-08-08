using EcX.Dominio.Interface;
using System.Data.Entity;

namespace EcX.Infra.Data.Repositorio
{
    public interface IDbContexto : IDatabaseContexto
    {
        DbSet<TEntidade> GetOrSetDbSet<TEntidade>()
       where TEntidade : class;
    }
}
