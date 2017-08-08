using System;
using System.Collections.Generic;
using Web.ViewModels;

namespace Web._IntegracaoAPI
{
    public class ClienteRepositorio : BaseRepositorioAPI
    {
        #region CONSTANTES DA API

        const string API_METODOS_INSERIR_PUT = "api/cliente/inserir";

        const string API_METODOS_ADICIONAR_PEDIDO_PUT = "api/cliente/adicionarpedido";
        const string API_METODOS_FINALIZAR_COMPRA_PUT = "api/cliente/finalizarcompra";

        const string API_METODOS_OBTER_HISTORICO_PEDIDO_GET = "api/cliente/obterhistoricopedido?id={0}";
        const string API_METODOS_OBTER_PEDIDOS_GET = "api/cliente/obterpedidocarrinho?id={0}";

        //erro
        const string API_METODOS_REMOVER_DELETE_PUT = "api/cliente/removeritenspedido";

        #endregion

        public Guid Inserir(UsuarioViewModel usuario)
        {
            return PutApi<UsuarioViewModel>(usuario, API_METODOS_INSERIR_PUT);
        }

        public ClienteViewModel ObterHistoricoPedido(Guid ID)
        {
            return GetByQueryString<ClienteViewModel>(string.Format(API_METODOS_OBTER_HISTORICO_PEDIDO_GET, ID));
        }
        public ClienteViewModel ObterCarrinho(Guid ID)
        {
            return GetByQueryString<ClienteViewModel>(string.Format(API_METODOS_OBTER_PEDIDOS_GET, ID));
        }

        public void AdicionarPedido(PedidoEntidadeViewModels pedidoViewModel)
        {
            PutApi<PedidoEntidadeViewModels>(pedidoViewModel, API_METODOS_ADICIONAR_PEDIDO_PUT);
        }

        public void FinalizarCompra(PedidoEntidadeViewModels pedidoViewModel)
        {
            PutApi<PedidoEntidadeViewModels>(pedidoViewModel, API_METODOS_FINALIZAR_COMPRA_PUT);
        }

        public void RemoverPedido(PedidoEntidadeViewModels pedidoViewModel)
        {
            PutApi<PedidoEntidadeViewModels>(pedidoViewModel, API_METODOS_REMOVER_DELETE_PUT);
        }
    }
}