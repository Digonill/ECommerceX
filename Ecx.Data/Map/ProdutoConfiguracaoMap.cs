using EcX.Dominio;
using EcX.Dominio.Entidade;
using System.Data.Entity.ModelConfiguration;

namespace EcX.Infra.Data.Map
{
    public class ProdutoConfiguracaoMap : EntityTypeConfiguration<ProdutoEntidade>, IConfiguracaoModelo
    {
        public ProdutoConfiguracaoMap()
        {
            Property(p => p.Nome)
                .IsRequired();
            Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(500);
            Property(p => p.Valor)
                .IsRequired();
        }
    }
}
