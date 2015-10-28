using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Projeto.Web.Models.Usuario;

namespace Projeto.Web.Areas.LoggedCliente.Controllers
{
    public class LoggedClienteController : Controller
    {
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            Session.Remove("clientelogado");
            Session.Abandon();

            return View("../Usuario/Login");
        }
    }
}