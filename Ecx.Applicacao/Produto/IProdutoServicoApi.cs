using EcX.Dominio.Entidade;
using EcX.Dominio.Interface;
using System;
using System.Collections.Generic;

namespace EcX.Aplicacao.Produto
{
    public interface IProdutoServicoApi : IServico
    {
        Guid Inserir(ProdutoEntidade entidade);

        void Atualizar(ProdutoEntidade entidade);

        void Remover(ProdutoEntidade entidade);

        ProdutoEntidade BuscarPeloID(string guid);

        IEnumerable<ProdutoEntidade> Listar();

        IEnumerable<ProdutoEntidade> BuscarPeloNome(string nome);

    }
}
