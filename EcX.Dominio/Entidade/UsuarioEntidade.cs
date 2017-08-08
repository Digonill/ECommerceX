using EcX.Dominio.Interface;

namespace EcX.Dominio.Entidade
{
    public class UsuarioEntidade : EntidadeGuidIDBase
    {
        public virtual string Login { get; set; }
        public virtual string Senha { get; set; }

        public bool IsAdministrador
        {
            get;
            internal set;
        }
    }

    public class AdministradorEntidade : UsuarioEntidade
    {
        public string Nome { get; set; }
    }
}
