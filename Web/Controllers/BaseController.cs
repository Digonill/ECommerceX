using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class BaseController : Controller
    {

        public UsuarioViewModel Usuario
        {
            get
            {
                UsuarioViewModel user;

                if (Session["UsuarioLogado"] != null)
                    try
                    {

                        user = Session["UsuarioLogado"] as UsuarioViewModel;
                    }
                    catch
                    {
                        user = null;
                    }
                else
                {
                    user = null;
                }

                return user;
            }
        }

    }
}