using EcX.Dominio.Interface.Entidade;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcX.Dominio.Entidade.Usuario
{
    public class Pedido: EntidadeGuidIDBase
    {
        public EnumStatusPedido StatusPedido { get; set; }
        public Collection<PedidoProduto> Produtos { get; set; }

        public double ValorTotal
        {
            get
            {
                if (Produtos.Count == 0)
                    return 0;

                var result = Produtos.Sum(item => item.Valor);

                return result;
            }
        }

        public DateTime DataCompra { get; set; }
    }
}
