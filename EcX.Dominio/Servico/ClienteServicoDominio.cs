using EcX.Dominio.Entidade;
using EcX.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EcX.Dominio.Servico
{
    public class ClienteServicoDominio : BaseServicoDominio<IRepositorioCliente, ClienteEntidade, Guid>, IClienteServicoDominio
    {
        public ClienteServicoDominio(IRepositorioCliente repositoriocliente) : base(repositoriocliente) { }

        public void FinalizarCompra(PedidoEntidade pedido)
        {
            var cliente = _repositorio.BuscarPeloID(pedido.ClienteID.Value);
            var pedidoNovo = cliente.Pedidos.Where(_ => _.ID == pedido.ID).SingleOrDefault();

            pedidoNovo.StatusPedido = EnumStatusPedido.Finalizado;
            _repositorio.Atualizar(cliente);
        }

        public ClienteEntidade ObterHistoricoPedido(Guid id)
        {
            var cliente = _repositorio.BuscarPeloID(id);
            cliente.Pedidos.RemoveAll(_ => _.StatusPedido != EnumStatusPedido.Finalizado);

            if (cliente.Pedidos.Count == 0)
            {
                return null;
            }
            {
                return cliente;
            }
        }

        public ClienteEntidade ObterPedidoCarrinho(Guid id)
        {
            var cliente = _repositorio.BuscarPeloID(id);
            cliente.Pedidos.RemoveAll(_ => _.StatusPedido != EnumStatusPedido.Carrinho);

            if (cliente.Pedidos.Count == 0)
            {
                return null;
            }
            {
                return cliente;
            }
        }

        public void RemoverItensPedido(PedidoEntidade pedido)
        {
            var cliente = _repositorio.BuscarPeloID(pedido.ClienteID.Value);

            cliente.Pedidos
                .Where(_ => _.ID == pedido.ID && _.StatusPedido == EnumStatusPedido.Carrinho)
                .First()
                .Itens.RemoveAll(_ => pedido.Itens.Exists(p => p.ID == _.ID));

            _repositorio.Atualizar(cliente);
        }

        public Guid AdicionarPedido(PedidoEntidade pedido)
        {
            var cliente = _repositorio.BuscarPeloID(pedido.ClienteID.Value);

            cliente.AdicionaOuAtualizaPedido(pedido);
            _repositorio.Atualizar(cliente);

            return cliente.ID;
        }
    }
}
