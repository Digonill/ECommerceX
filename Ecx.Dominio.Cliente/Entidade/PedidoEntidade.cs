using EcX.Dominio.Interface.Entidade;
using System;
using System.Collections.ObjectModel;

namespace EcX.Dominio.Cliente
{
    public class PedidoEntidade : EntidadeGuidIDBase
    {
        public DateTime DataCriacao { get; set; }
        public DateTime DataCompra { get; set; }
        public Guid ClienteID { get; set; }
        public EnumStatusPedido? StatusPedido { get; set; }
        public virtual Collection<ItensPedidoEntidade> Itens { get; set; }
        public virtual ClienteEntidade Cliente { get; set; }
    }
}
