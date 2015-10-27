using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Web.Areas.LoggedFuncionario.Controllers
{
    public class LoggedFuncionarioController : Controller
    {
        // GET: LoggedFuncionario/LoggedFuncionario
        public ActionResult Index()
        {
            return View();
        }
    }
}