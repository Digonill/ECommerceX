using EcX.Dominio.Entidade;
using EcX.Dominio.Repositorio;
using System;
using System.Collections.Generic;

namespace EcX.Dominio.Servico
{
    public class ProdutoServicoDominio : BaseServicoDominio<IRepositorioProduto, ProdutoEntidade, Guid>, IProdutoServicoDominio
    {
        public ProdutoServicoDominio(IRepositorioProduto respositorio) : base(respositorio)
        {
        }

        public IEnumerable<ProdutoEntidade> BuscarPorNome(string nome)
        {
            return _repositorio.BuscarPorNome(nome);
        }
    }
}
