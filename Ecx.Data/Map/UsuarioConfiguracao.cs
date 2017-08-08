namespace EcX.Infra.Data.Map
{
    using Dominio;
    using Dominio.Entidade;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.ModelConfiguration;


    public class UsuarioConfiguracaoMap : EntityTypeConfiguration<UsuarioEntidade>, IConfiguracaoModelo
    {

        public UsuarioConfiguracaoMap()
        {
            Property(u => u.Login)
                  .IsRequired()
                   .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_LOGIN", 1) { IsUnique = true }));

            Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(8);
        }
    }
}
