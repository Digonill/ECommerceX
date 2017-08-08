using EcX.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EcX.Dominio.Entidade
{
    public class PedidoEntidade : EntidadeGuidIDBase
    {
        public DateTime DataCriacao { get; set; }
        public DateTime DataCompra { get; set; }

        public EnumStatusPedido? StatusPedido { get; set; }
        public virtual List<ItensPedidoEntidade> Itens { get; set; }

        public virtual Guid? ClienteID { get; set; }
        public virtual ClienteEntidade Cliente { get; set; }

        public void AdicionarOuAtualizarItemPedido(ItensPedidoEntidade item)
        {
            var existente = Itens.Where(_ => _.ID == item.ID || _.NomeProduto == item.NomeProduto).SingleOrDefault();
            if (existente != null)
            {
                existente.Quantidade += 1;
            }
            else { Itens.Add(item); }
        }


    }
}
