using EcX.Dominio.Entidade;
using EcX.Dominio.Repositorio;
using System;
using System.Linq;

namespace EcX.Dominio.Servico
{

    public class UsuarioServicoDominio : BaseServicoDominio<IRepositorioUsuario, UsuarioEntidade, Guid>, IUsuarioServicoDominio
    {
        public UsuarioServicoDominio(IRepositorioUsuario repositoriousuario) : base(repositoriousuario) { }

        public UsuarioEntidade Autenticar(UsuarioEntidade entidade)
        {
            if (entidade == null)
                throw new ArgumentNullException("UsuarioEntidade");

            if (entidade.Login == "" || entidade.Senha == "")
                throw new Exception("Dados da entidade usuario inválido");

            var usuario = _repositorio.Listar().Where(_ => _.Login.ToUpper().Equals(entidade.Login.ToUpper()) && _.Senha.ToUpper().Equals(entidade.Senha.ToUpper())).FirstOrDefault();

            if (usuario != null)
                usuario.IsAdministrador = _repositorio.VerificarAdminSistema(usuario.ID);

            return usuario;
        }
    }
}
