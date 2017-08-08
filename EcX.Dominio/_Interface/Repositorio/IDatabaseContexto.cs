
using System;

namespace EcX.Dominio.Interface
{
    public interface IDatabaseContexto : IDisposable
    {
        bool ReadOnly { get; set; }

        int SaveChanges();
        void Add<TEntidade>(TEntidade entidade)
            where TEntidade : class, IEntidade;

        void Update<TEntidade>(TEntidade entidade)
            where TEntidade : class, IEntidade;

        void Delete<TEntidade>(TEntidade entidade)
            where TEntidade : class, IEntidade;

        TEntidade GetByID<TIdentificador, TEntidade>(TIdentificador id)
            where TEntidade : class, IEntidade<TIdentificador>;
        
    }
}
