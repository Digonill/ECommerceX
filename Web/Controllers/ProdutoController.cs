using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Web._IntegracaoAPI;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ProdutoController : Controller
    {
        ProdutoRepositorio api;

        public ProdutoController()
        {
            api = new ProdutoRepositorio();
            ModelState.Clear();
        }
        // GET: Produto
        public ActionResult Index()
        {

            List<ProdutoViewModel> produtos = api.BuscarTodos();

            return View(produtos); ;
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        public ActionResult Create(ProdutoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    api.Inserir(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERRO", ex.Message);
                return View();
            }
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(Guid id)
        {
            ProdutoViewModel model = api.BuscarID(id);
            return View(model);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Edit(ProdutoViewModel model, FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    api.Atualizar(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ERRO", ex.Message);
                return View();
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(ProdutoViewModel model)
        {
            model = api.BuscarID(model.ID);

            return View(model);
        }

        // POST: Produto/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid ID, FormCollection collection)
        {
            try
            {
                var entidade = api.BuscarID(ID);
                api.Remover(entidade);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Erro", ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}
