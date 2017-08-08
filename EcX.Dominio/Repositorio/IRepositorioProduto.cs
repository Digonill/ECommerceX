using EcX.Dominio.Entidade;
using EcX.Dominio.Interface;
using System;
using System.Collections.Generic;

namespace EcX.Dominio.Repositorio
{
    public interface IRepositorioProduto : IRepositorio<ProdutoEntidade, Guid>
    {
        IEnumerable<ProdutoEntidade> BuscarPorNome(string nome);
    }
}
