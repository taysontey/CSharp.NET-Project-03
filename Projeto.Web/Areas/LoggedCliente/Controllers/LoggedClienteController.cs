using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Web.Areas.LoggedCliente.Controllers
{
    public class LoggedClienteController : Controller
    {
        // GET: LoggedCliente/LoggedCliente
        public ActionResult Index()
        {
            return View();
        }
    }
}