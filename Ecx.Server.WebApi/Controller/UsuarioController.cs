using Ecx.Aplicacao.Usuario;
using EcX.Dominio.Entidade;
using System.Web.Http;

namespace EcX.Server.WebApi.Controller
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioServicoApi _usuarioServico;

        public UsuarioController(IUsuarioServicoApi usuarioservico_)
        {
            _usuarioServico = usuarioservico_;
        }        

        [HttpPost]
        [Route("Autenticar")]
        public IHttpActionResult Autenticar([FromBody]UsuarioEntidade request)
        {
            return Ok(_usuarioServico.Autenticar(request));
        }
    }  
}
