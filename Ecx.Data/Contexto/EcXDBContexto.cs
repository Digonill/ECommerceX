using EcX.Dominio;
using EcX.Dominio.Entidade;
using EcX.Dominio.Interface;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace EcX.Infra.Data.Contexto
{
    public class EcXDBContexto : GenericDatabase<EcXDBContexto>
    {
        #region Construtor
        public EcXDBContexto() : base("ECXDB")
        {
            Database.SetInitializer<EcXDBContexto>(new DBSetup());

            this.Database.Log = s => Debug.WriteLine(s);
        }

        #endregion

        #region Configuracoes

        private void MapearEntidades(DbModelBuilder modelBuilder)
        {
            var tiposMap = (from x in Assembly.GetExecutingAssembly().GetTypes()
                            where x.IsClass && typeof(IConfiguracaoModelo).IsAssignableFrom(x)
                            select x).ToList();

            foreach (var tipo in tiposMap)
            {
                dynamic mapEntidade = Activator.CreateInstance(tipo);
                modelBuilder.Configurations.Add(mapEntidade);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Add<OneToManyCascadeDeleteConvention>();

            //Configura a PK de TODAS ENTIDADES 
            modelBuilder.Properties()
                .Where(p => p.Name == "ID")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(200));


            MapearEntidades(modelBuilder);

            //TODO: Poderia adicionar dinamicamente utilizando o *EntityTypeConfiguration*
            modelBuilder.Entity<UsuarioEntidade>().ToTable("Usuario");
            modelBuilder.Entity<AdministradorEntidade>().ToTable("Administrador");
            modelBuilder.Entity<ClienteEntidade>().ToTable("Cliente");
            modelBuilder.Entity<PedidoEntidade>().ToTable("Pedido");
            modelBuilder.Entity<ItensPedidoEntidade>().ToTable("ItensPedido");
            modelBuilder.Entity<ProdutoEntidade>().ToTable("Produto");

        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => (e.State == EntityState.Added || e.State == EntityState.Modified) && e.Entity is IEntidade))
            {
                var entityGuidId = entry.Entity as EntidadeGuidIDBase;
                if (entityGuidId != null && entityGuidId.ID == Guid.Empty)
                {
                    entityGuidId.ID = Guid.NewGuid();
                }
            }

            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Table: {0} Property: {1} Error: {2}",
                            validationErrors.Entry.Entity.GetType().Name,
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }
                throw;
            }
        }

        #endregion
    }
}
