using System.Collections.Generic;

namespace EcX.Dominio.Cliente
{
    public class ClienteEntidade : UsuarioEntidade
    {
        public string Nome { get; set; }

        public virtual ICollection<PedidoEntidade> Pedidos { get; set; }
    }
}
