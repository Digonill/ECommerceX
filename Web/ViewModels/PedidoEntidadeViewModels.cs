using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public enum EnumStatusPedido
    {
        Carrinho = 1,
        Finalizado = 2
    }

    public class PedidoEntidadeViewModels
    {
        public PedidoEntidadeViewModels()
        {
            Itens = new List<ItensPedidoEntidadeViewModels>();
        }

        [Key]
        [DisplayName("Número do Pedido")]
        public Guid ID { get; set; }

        [DisplayName("Data do Pedido")]
        public DateTime DataCriacao { get; set; }

        [DisplayName("Data do Pagamento")]
        public DateTime DataCompra { get; set; }

        [DisplayName("Status do Pedido")]
        public EnumStatusPedido StatusPedido { get; set; }
        public Guid ClienteID { get; set; }

        [DisplayName("Valor Total")]
        public decimal ValorTotal
        {
            get
            {
                if (Itens != null)
                {
                    decimal valor = 0;
                    Itens.ForEach(_ =>
                    {
                        valor += _.ValorTotal;
                    });

                    return valor;
                }
                return 0;
            }
        }

        public List<ItensPedidoEntidadeViewModels> Itens { get; set; }
    }    
}