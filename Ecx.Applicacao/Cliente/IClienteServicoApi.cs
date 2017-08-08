using EcX.Dominio.Entidade;
using EcX.Dominio.Interface;
using System;
using System.Collections.Generic;

namespace EcX.Aplicacao.Cliente
{
    public interface IClienteServicoApi : IServico
    {
        Guid Inserir(ClienteEntidade entidade);
        ClienteEntidade ObterHistoricoPedido(Guid id);
        ClienteEntidade ObterPedidoCarrinho(Guid id);
        void FinalizarCompra(PedidoEntidade pedido);
        Guid AdicionarPedido(PedidoEntidade pedido);
        void RemoverItensPedido(PedidoEntidade pedido);

    }
}
