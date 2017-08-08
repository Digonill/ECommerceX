using EcX.Dominio.Entidade;
using EcX.Dominio.Servico;
using System;
using System.Collections.Generic;

namespace EcX.Aplicacao.Produto
{
    public class ProdutoServicoApi : IProdutoServicoApi
    {
        private readonly IProdutoServicoDominio dominio;

        public ProdutoServicoApi(IProdutoServicoDominio dominio_)
        {
            dominio = dominio_;
        }

        public IEnumerable<ProdutoEntidade> Listar()
        {
            return dominio.Listar();
        }

        public void Atualizar(ProdutoEntidade request)
        {
            dominio.Atualizar(request);
        }

        public void Remover(ProdutoEntidade request)
        {
            dominio.Remover(request);
        }

        public ProdutoEntidade BuscarPeloID(string Guid)
        {
            Guid id;
            System.Guid.TryParse(Guid, out id);

            return dominio.BuscarPeloID(id);
        }

        public Guid Inserir(ProdutoEntidade request)
        {
            dominio.Inserir(request);
            return request.ID;
        }

        public IEnumerable<ProdutoEntidade> BuscarPeloNome(string nome)
        {
            return dominio.BuscarPorNome(nome);
        }
    }
}
