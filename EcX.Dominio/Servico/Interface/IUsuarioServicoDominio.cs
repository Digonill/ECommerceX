using System;
using EcX.Dominio.Interface;
using EcX.Dominio.Entidade;

namespace EcX.Dominio.Servico
{
    public interface IUsuarioServicoDominio : ICRUDServicoBase<UsuarioEntidade, Guid>
    {
        UsuarioEntidade Autenticar(UsuarioEntidade entidade);    }
}