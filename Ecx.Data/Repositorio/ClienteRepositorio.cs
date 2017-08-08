namespace EcX.Infra.Data.Repositorio
{
    using Dominio.Entidade;
    using Dominio.Interface;
    using Dominio.Repositorio;
    using System;



    public class ClienteRepositorio : RepositorioBase<ClienteEntidade, Guid>, IRepositorioCliente
    {
        public ClienteRepositorio(IDatabaseContexto contexto) : base(contexto)
        {
        }
    }
}
