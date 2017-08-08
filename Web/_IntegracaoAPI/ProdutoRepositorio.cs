using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Web.ViewModels;

namespace Web._IntegracaoAPI
{
    public class ProdutoRepositorio : BaseRepositorioAPI
    {
        #region Construtor      

        public ProdutoRepositorio()
        {

        }
        #endregion

        #region CONSTANTES DA API

        const string API_METODOS_LISTAR_GET = "/api/produto/listar";
        const string API_METODOS_BUSCARID_GET = "api/produto/buscarid/?guid={0}";
        const string API_METODOS_BUSCARNOME_GET = "/api/produto/BuscarPeloNome/?nome={0}";

        const string API_METODOS_INSERIR_POST = "api/produto/inserir";
        const string API_METODOS_REMOVER_PUT = "api/produto/remover";
        const string API_METODOS_ATUALIZAR_POST = "api/produto/atualizar";


        #endregion

        public List<ProdutoViewModel> BuscarTodos()
        {
            return GetALL<ProdutoViewModel>(API_METODOS_LISTAR_GET);
        }

        //NOK
        public void Atualizar(ProdutoViewModel vwmodel)
        {
            PostApi(vwmodel, API_METODOS_ATUALIZAR_POST);
        }
        //OK
        public ProdutoViewModel BuscarID(Guid ID)
        {
            var result = GetByQueryString<ProdutoViewModel>(string.Format(API_METODOS_BUSCARID_GET, ID));

            if (result != null)
            {
                return result;
            }
            else { return new ProdutoViewModel(); }
        }

        public List<ProdutoViewModel> BuscarPeloNome(string nome)
        {
            return GetByQueryString<List<ProdutoViewModel>>(string.Format(API_METODOS_BUSCARNOME_GET, nome));
        }
        //OK
        public Guid Inserir(ProdutoViewModel vwmodel)
        {
            return PutApi<ProdutoViewModel>(vwmodel, API_METODOS_INSERIR_POST);
        }
        //OK
        public void Remover(ProdutoViewModel vwmodel)
        {
            PutApi(vwmodel, API_METODOS_REMOVER_PUT);
        }
    }
}