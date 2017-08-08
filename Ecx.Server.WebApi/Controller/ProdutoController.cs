using EcX.Aplicacao.Produto;
using EcX.Dominio.Entidade;
using System.Web.Http;

namespace EcX.Server.WebApi.Produto
{
    [RoutePrefix("api/produto")]
    public class ProdutoController : ApiController
    {
        private readonly IProdutoServicoApi _produtoServico;
        public ProdutoController(IProdutoServicoApi produtoServico_)
        {
            _produtoServico = produtoServico_;
        }

        [HttpPut]
        [Route("inserir")]
        public IHttpActionResult Inserir([FromBody]ProdutoEntidade request)
        {
            return Ok(_produtoServico.Inserir(request));
        }

        [HttpGet]
        [Route("listar")]
        public IHttpActionResult Listar()
        {
            return Ok(_produtoServico.Listar());
        }

        [HttpGet]
        [Route("buscarid")]
        public IHttpActionResult BuscarId([FromUri]string guid)
        {
            return Ok(_produtoServico.BuscarPeloID(guid));
        }

        [HttpGet]
        [Route("BuscarPeloNome")]
        public IHttpActionResult BuscarPeloNome([FromUri]string nome)
        {
            return Ok(_produtoServico.BuscarPeloNome(nome));
        }


        [HttpPost]
        [Route("atualizar")]
        public IHttpActionResult Atualizar([FromBody]ProdutoEntidade request)
        {
            _produtoServico.Atualizar(request);
            return Ok();
        }

        [HttpPut]
        [Route("remover")]
        public IHttpActionResult Remover([FromBody]ProdutoEntidade request)
        {
            _produtoServico.Remover(request);
            return Ok();
        }
    }
}
