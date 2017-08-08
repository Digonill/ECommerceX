namespace EcX.Infra.Data.Repositorio
{
    using Dominio.Interface;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;


    public class RepositorioBase<TEntidade, TIdentificador> : IDisposable, IRepositorio<TEntidade, TIdentificador>
        where TEntidade : class, IEntidade<TIdentificador>
        where TIdentificador : IEquatable<TIdentificador>
    {

        protected IDatabaseContexto _contextodb;
        protected IDbContexto DbContext => (IDbContexto)_contextodb;
        protected virtual DbSet<TEntidade> DbSet => DbContext.GetOrSetDbSet<TEntidade>();

        public RepositorioBase(IDatabaseContexto contexto_)
        {
            _contextodb = contexto_;
        }

        public void Atualizar(TEntidade entidade)
        {
            _contextodb.Update(entidade);
            _contextodb.SaveChanges();
        }

        public TEntidade BuscarPeloID(TIdentificador ID)
        {
            try
            {
                return GetWithIncludes().First(_ => _.ID.Equals(ID));
            }
            catch
            {
                throw new Exception(string.Format("Não Foi possivel encontrar a entidade ({0}) do ID: {1}", typeof(TEntidade), ID));
            }
        }

        public void Delete(TEntidade entidade)
        {
            var logica = entidade as IEntidadeExclusaoLogica;
            if (logica != null)
            {
                var e = logica;
                e.RegistroExcluido = true;
                _contextodb.Update(entidade);
            }
            else
            {
                _contextodb.Delete(entidade);
            }
            _contextodb.SaveChanges();
        }

        public void Inserir(TEntidade entidade)
        {
            _contextodb.Add(entidade);
            _contextodb.SaveChanges();

        }

        public IEnumerable<TEntidade> Listar()
        {
            return GetWithIncludes().ToList();
        }

        public virtual IQueryable<TEntidade> GetWithIncludes()
        {
            return DbSet;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_contextodb != null)
                {
                    _contextodb.Dispose();
                }
            }
        }
    }
}
