using System;
using EcX.Dominio.Entidade;
using EcX.Dominio.Servico;

namespace Ecx.Aplicacao.Usuario
{
    public class UsuarioServicoApi : IUsuarioServicoApi
    {
        private readonly IUsuarioServicoDominio dominio;

        public UsuarioServicoApi(IUsuarioServicoDominio dominio_)
        {
            dominio = dominio_;
        }

        public UsuarioEntidade Autenticar(UsuarioEntidade request)
        {
            return dominio.Autenticar(request);
        }

        public Guid Inserir(UsuarioEntidade request)
        {
            dominio.Inserir(request);
            return request.ID;
        }
    }
}
