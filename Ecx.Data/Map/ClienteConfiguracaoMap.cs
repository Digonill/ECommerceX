using EcX.Dominio;
using EcX.Dominio.Entidade;
using System.Data.Entity.ModelConfiguration;

namespace EcX.Infra.Data.Map
{
    public class ClienteConfiguracaoMap : EntityTypeConfiguration<ClienteEntidade>, IConfiguracaoModelo
    {
        public ClienteConfiguracaoMap()
        {
            Property(c => c.Nome)
                .IsRequired();
        }
    }
}
