using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Projeto.Web.Areas.LoggedFuncionario.Controllers
{
    public class LoggedFuncionarioController : Controller
    {
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            Session.Remove("funcionariologado");
            Session.Abandon();

            return View("../Usuario/Login");
        }
    }
}