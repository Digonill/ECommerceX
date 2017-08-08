using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web._IntegracaoAPI;
using Web.Models;
using Web.ViewModels;

namespace IdentitySample.Controllers
{
    public class AccountController : Controller
    {
        public AccountController()
        {
        }
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                UsuarioViewModel UsuarioLogado = null;

                using (var repositorio = new UsuarioRepositorio())
                {
                    var usuario = new UsuarioViewModel()
                    {
                        Login = model.Email,
                        Senha = model.Password
                    };

                    UsuarioLogado = repositorio.Autenticar(usuario);
                }

                if (UsuarioLogado.ID != Guid.Empty)
                {

                    string role = (UsuarioLogado.IsAdministrador ? "Admin" : "Cliente");

                    var authTicket = new FormsAuthenticationTicket(1, UsuarioLogado.Login, DateTime.Now, DateTime.Now.AddMinutes(20), false, role);

                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);

                    Session["UsuarioLogado"] = UsuarioLogado;

                    return RedirectToLocal(returnUrl);

                }
                else
                {
                    ModelState.AddModelError("Erro", "Usuario inválido!");
                }
            }
            return View();
        }


        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult LogOff()
        {
            Session.Clear();
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ClienteRepositorio cliente = new ClienteRepositorio();

                UsuarioViewModel NovoUsuario = new UsuarioViewModel()
                {
                    Nome = model.Nome,
                    Login = model.Email,
                    Senha = model.Password

                };

                cliente.Inserir(NovoUsuario);

                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
            }
        }

    }
}