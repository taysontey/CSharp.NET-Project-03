using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Projeto.Web.Models.Usuario;
using Projeto.Web.Areas.LoggedFuncionario.Models;
using Projeto.Entity.Entities;
using Projeto.DAL.Persistence;
using Projeto.Security.Security;

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

        [Authorize]
        public ActionResult NovaSenha()
        {
            return View();
        }

        #region Metodos AJAX

        

        #endregion
    }
}