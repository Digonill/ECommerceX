using EcX.Dominio.Interface.Entidade;
using System;

namespace EcX.Dominio.Cliente
{
    public class ItensPedidoEntidade : EntidadeGuidIDBase
    {
        public string NomeProduto { get; set; }

        public decimal ValorUnitario { get; set; }

        public decimal ValorTotal
        {
            get
            {
                try
                {


                    return ValorUnitario * Quantidade;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public int Quantidade { get; set; }

        public Guid PedidoID { get; set; }

        public virtual PedidoEntidade Pedido { get; set; }
    }
}
