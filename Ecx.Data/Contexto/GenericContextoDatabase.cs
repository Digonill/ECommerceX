using EcX.Infra.Data.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using EcX.Dominio.Interface;

namespace EcX.Infra.Data.Contexto
{
    public abstract class GenericDatabase<TDbContexto> : DbContext, IDbContexto
         where TDbContexto : DbContext
    {
        private IDictionary<Type, object> _dbSets;

        protected GenericDatabase(string databaseName) : base(databaseName)
        {
            _dbSets = new Dictionary<Type, object>();
        }

        public bool ReadOnly
        {
            get
            {
                return this.Configuration.AutoDetectChangesEnabled;
            }

            set
            {
                this.Configuration.AutoDetectChangesEnabled = !value;
            }
        }

        public DbSet<TEntidade> GetOrSetDbSet<TEntidade>() where TEntidade : class
        {
            DbSet<TEntidade> dbSet = null;
            if (_dbSets.ContainsKey(typeof(TEntidade)))
            {
                dbSet = (DbSet<TEntidade>)_dbSets[typeof(TEntidade)];
            }
            else
            {
                dbSet = this.Set<TEntidade>() as DbSet<TEntidade>;
                _dbSets.Add(typeof(TEntidade), dbSet);
            }

            return dbSet;
        }

        public void Add<TEntidade>(TEntidade entidade) where TEntidade : class, IEntidade
        {
            var db = GetOrSetDbSet<TEntidade>();
            db.Add(entidade);
        }

        public void Delete<TEntidade>(TEntidade entidade) where TEntidade : class, IEntidade
        {
            var db = GetOrSetDbSet<TEntidade>();
            db.Remove(entidade);
        }

        public TEntidade GetByID<TIdentificador, TEntidade>(TIdentificador id) where TEntidade : class, IEntidade<TIdentificador>
        {
            var db = GetOrSetDbSet<TEntidade>();
            return db.Find(id);
        }

        public void Update<TEntidade>(TEntidade entidade)
            where TEntidade : class, IEntidade
        {
            var db = GetOrSetDbSet<TEntidade>();

            var obj = this.Entry(entidade);
            db.Attach(entidade);
            obj.State = EntityState.Modified;
        }
    }
}