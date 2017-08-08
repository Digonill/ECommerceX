using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Web._IntegracaoAPI;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    [HandleError(View = "Error")]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            var api = new ProdutoRepositorio();
            List<ProdutoViewModel> produtos = api.BuscarTodos();

            return View(produtos);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Pesquisar(FormCollection collection)
        {
            if (collection.Count > 0)
            {
                var Nome = collection[0];
                var api = new ProdutoRepositorio();
                List<ProdutoViewModel> produtos = api.BuscarPeloNome(Nome);

                return View("Index", produtos);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "E-commerce X";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Rodrigo Oliveira <Rodrigo.Oliveiras@outlook.com>";

            return View();
        }

        [AllowAnonymous]        
        public ActionResult Error()
        {
            
            return View();
        }
    }
}