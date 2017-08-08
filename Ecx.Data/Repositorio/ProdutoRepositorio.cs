namespace EcX.Infra.Data.Repositorio
{
    using Dominio.Entidade;
    using Dominio.Interface;
    using Dominio.Repositorio;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ProdutoRepositorio : RepositorioBase<ProdutoEntidade, Guid>, IRepositorioProduto
    {
        public ProdutoRepositorio(IDatabaseContexto contexto) : base(contexto)
        {
        }

        public IEnumerable<ProdutoEntidade> BuscarPorNome(string nome)
        {
            return DbSet.Where(p => p.Nome.Contains(nome) || p.Descricao.Contains(nome));
        }
    }
}
