namespace EcX.Dominio.Entidade
{
    using EcX.Dominio.Interface;
    using System;


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

        public Guid? PedidoID { get; set; }

        public virtual PedidoEntidade  Pedido { get; set; }
    }
}
