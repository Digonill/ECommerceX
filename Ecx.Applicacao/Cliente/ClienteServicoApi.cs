using EcX.Aplicacao.Cliente;
using System;
using System.Collections.Generic;
using EcX.Dominio.Entidade;
using EcX.Dominio.Servico;

namespace Ecx.Aplicacao.Cliente
{
    public class ClienteServicoApi : IClienteServicoApi
    {
        IClienteServicoDominio _dominio;

        public ClienteServicoApi(IClienteServicoDominio servicodominio_)
        {
            _dominio = servicodominio_;
        }
        public Guid AdicionarPedido(PedidoEntidade pedido)
        {
            return _dominio.AdicionarPedido(pedido);
        }

        public void FinalizarCompra(PedidoEntidade pedido)
        {
            _dominio.FinalizarCompra(pedido);
        }

        public Guid Inserir(ClienteEntidade entidade)
        {
            _dominio.Inserir(entidade);
            return entidade.ID;
        }

        public ClienteEntidade ObterHistoricoPedido(Guid id)
        {
            return _dominio.ObterHistoricoPedido(id);
        }

        public ClienteEntidade ObterPedidoCarrinho(Guid id)
        {
            return _dominio.ObterPedidoCarrinho(id);
        }

        public void RemoverItensPedido(PedidoEntidade pedido)
        {
            _dominio.RemoverItensPedido(pedido);
        }
    }
}
