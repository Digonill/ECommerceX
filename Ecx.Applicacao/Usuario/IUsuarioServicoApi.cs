using EcX.Dominio.Entidade;
using System;

namespace Ecx.Aplicacao.Usuario
{
    public interface IUsuarioServicoApi
    {
        Guid Inserir(UsuarioEntidade request);

        UsuarioEntidade Autenticar(UsuarioEntidade request);
    }
}
