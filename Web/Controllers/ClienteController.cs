using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web._IntegracaoAPI;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize(Roles = "Cliente")]
    public class ClienteController : BaseController
    {
        ClienteRepositorio repositorio;
        public ClienteController()
        {
            repositorio = new ClienteRepositorio();
        }
        // GET: Cliente
        public ActionResult Index()
        {
            List<PedidoEntidadeViewModels> PedidosFinalizados;
            ClienteViewModel cliente = repositorio.ObterHistoricoPedido(base.Usuario.ID);

            if (cliente == null)
                PedidosFinalizados = new List<PedidoEntidadeViewModels>();
            else
            {
                TempData["HistoricoPedidos"] = cliente;
                PedidosFinalizados = cliente.Pedidos;
            }

            return View(PedidosFinalizados);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(Guid id)
        {
            if (TempData["HistoricoPedidos"] != null)
            {
                var cliente = TempData["HistoricoPedidos"] as ClienteViewModel;
                var model = cliente.Pedidos.Where(_ => _.ID == id).First().Itens;
                return View(model);
            }
            else
            { return View(); }
        }

        [HttpPost]
        public JsonResult AdicionarProduto(string Idproduto)
        {
            JsonResult jsonresult = null;
            try
            {
                //Resgata o produto
                var produto = getProduto(Idproduto);

                //Resgata o pedido aberto do cliente

                var pedido = new PedidoEntidadeViewModels();

                pedido.ClienteID = this.Usuario.ID;
                pedido.DataCriacao = DateTime.Now;
                pedido.DataCompra = DateTime.Now;
                pedido.StatusPedido = EnumStatusPedido.Carrinho;
                pedido.Itens.Add(new ItensPedidoEntidadeViewModels()
                {
                    NomeProduto = produto.Nome,
                    Quantidade = 1,
                    ValorUnitario = produto.Valor
                });

                repositorio.AdicionarPedido(pedido);

                jsonresult = Json("OK", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                jsonresult = Json(ex, JsonRequestBehavior.AllowGet);
            }

            return jsonresult;
        }

        private ProdutoViewModel getProduto(string id)
        {
            Guid idproduto = Guid.Parse(id);
            var repositorio = new ProdutoRepositorio();
            return repositorio.BuscarID(idproduto);
        }

        [HttpGet]
        public ActionResult CarrinhoCompra()
        {
            ClienteViewModel cliente = repositorio.ObterCarrinho(base.Usuario.ID);

            if (cliente != null)
                return View(cliente.Pedidos[0]);
            else
                return View(new PedidoEntidadeViewModels());
        }

        public ActionResult RemoverItemPedido(Guid idPedido, Guid IditemPedido)
        {
            PedidoEntidadeViewModels pedido = new PedidoEntidadeViewModels()
            {
                ClienteID = Usuario.ID,
                ID = idPedido,
                Itens = new List<ItensPedidoEntidadeViewModels>()
            };

            pedido.Itens.Add(new ItensPedidoEntidadeViewModels()
            {
                ID = IditemPedido
            });

            repositorio.RemoverPedido(pedido);

            return RedirectToAction("CarrinhoCompra");
        }

        public ActionResult FinalizarCompra(Guid id)
        {
            if (Guid.Empty != id)
            {
                PedidoEntidadeViewModels pedido = new PedidoEntidadeViewModels()
                {
                    ID = id,
                    ClienteID = Usuario.ID
                };

                repositorio.FinalizarCompra(pedido);
            }
            return RedirectToAction("Index");
        }
    }
}
