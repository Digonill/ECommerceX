using System.Collections.Generic;
using System.Linq;

namespace EcX.Dominio.Entidade
{
    public class ClienteEntidade : UsuarioEntidade
    {
        public string Nome { get; set; }

        public virtual List<PedidoEntidade> Pedidos { get; set; }

        public void AdicionaOuAtualizaPedido(PedidoEntidade NovoPedido)
        {
            var pedido = Pedidos.Where(_ => _.StatusPedido == EnumStatusPedido.Carrinho).SingleOrDefault();

            if (pedido == null)
            {
                Pedidos.Add(NovoPedido);
            }
            else
            {
                foreach (var item in NovoPedido.Itens)
                {
                    pedido.AdicionarOuAtualizarItemPedido(item);
                }
            }
        }
    }


}
