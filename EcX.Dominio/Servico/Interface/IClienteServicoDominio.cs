using System;
using EcX.Dominio.Interface;
using EcX.Dominio.Entidade;
using System.Collections.Generic;

namespace EcX.Dominio.Servico
{
    public interface IClienteServicoDominio : ICRUDServicoBase<ClienteEntidade, Guid>
    {
        ClienteEntidade ObterHistoricoPedido(Guid id);
        void FinalizarCompra(PedidoEntidade pedido);
        Guid AdicionarPedido(PedidoEntidade pedido);
        void RemoverItensPedido(PedidoEntidade pedido);
        ClienteEntidade ObterPedidoCarrinho(Guid id);
    }
}
