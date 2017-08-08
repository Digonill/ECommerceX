using EcX.Aplicacao.Cliente;
using EcX.Dominio.Entidade;
using System;
using System.Web.Http;

namespace EcX.Server.WebApi.Controller
{
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiController
    {
        private readonly IClienteServicoApi _clienteServico;

        public ClienteController(IClienteServicoApi clienteservico_)
        {
            _clienteServico = clienteservico_;
        }

        [HttpPut]
        [Route("inserir")]
        public IHttpActionResult Inserir([FromBody]ClienteEntidade request)
        {
            return Ok(_clienteServico.Inserir(request));
        }

        [HttpPut]
        [Route("finalizarcompra")]
        public IHttpActionResult FinalizarCompra([FromBody]PedidoEntidade request)
        {
            _clienteServico.FinalizarCompra(request);
            return Ok();
        }

        [HttpPut]
        [Route("adicionarpedido")]
        public IHttpActionResult AdicionarPedido([FromBody]PedidoEntidade request)
        {            
            return Ok(_clienteServico.AdicionarPedido(request));
        }

        [HttpPut]
        [Route("removeritenspedido")]
        public IHttpActionResult RemoverItensPedido([FromBody]PedidoEntidade request)
        {
            _clienteServico.RemoverItensPedido(request);
            return Ok();
        }

        [HttpGet]
        [Route("obterhistoricopedido")]
        public IHttpActionResult ObterHistoricoPedido([FromUri] Guid id)
        {
            return Ok(_clienteServico.ObterHistoricoPedido(id));
        }

        [HttpGet]
        [Route("obterpedidocarrinho")]
        public IHttpActionResult ObterPedidoCarrinho([FromUri] Guid id)
        {
            return Ok(_clienteServico.ObterPedidoCarrinho(id));
        }
    }

}
