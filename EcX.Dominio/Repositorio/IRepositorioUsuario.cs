using EcX.Dominio.Entidade;
using EcX.Dominio.Interface;
using System;

namespace EcX.Dominio.Repositorio
{
    public interface IRepositorioUsuario : IRepositorio<UsuarioEntidade, Guid>
    {
        bool VerificarAdminSistema(Guid ID);
        
    }
}
