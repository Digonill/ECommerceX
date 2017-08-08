using EcX.Dominio.Entidade;
using EcX.Dominio.Repositorio;
using System;
using System.Linq;

namespace EcX.Dominio.Servico
{

    public class UsuarioServicoDominio : BaseServicoDominio<IRepositorioUsuario, UsuarioEntidade, Guid>, IUsuarioServicoDominio
    {
        public UsuarioServicoDominio(IRepositorioUsuario repositoriocliente) : base(repositoriocliente) { }

        public UsuarioEntidade Autenticar(UsuarioEntidade entidade)
        {
            if (entidade == null)
                throw new ArgumentNullException("UsuarioEntidade");

            var usuario = _repositorio.Listar().Where(_ => _.Login.ToUpper().Equals(entidade.Login.ToUpper()) && _.Senha.ToUpper().Equals(entidade.Senha.ToUpper())).FirstOrDefault();
            usuario.IsAdministrador = _repositorio.VerificarAdminSistema(usuario.ID);

            return usuario;
        }
    }
}
