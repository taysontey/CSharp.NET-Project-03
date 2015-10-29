using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Projeto.Web.Models.Usuario;
using Projeto.Entity.Entities;
using Projeto.DAL.Persistence;
using Projeto.Web.Areas.LoggedCliente.Models;
using System.Globalization;

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

        [Authorize]
        public ActionResult Cadastro()
        {
            return View();
        }

        #region Metodos AJAX

        public JsonResult AbrirChamado(ChamadoModelCadastro model)
        {
            try
            {
                Cliente c = (Cliente)Session["clientelogado"];
                
                Chamado cd = new Chamado();
                cd.DataAbertura = DateTime.Now;
                cd.Assunto = model.Assunto;
                cd.Descricao = model.Descricao;
                cd.Situacao = Situacao.Aberto;
                cd.Cliente = c;

                ChamadoDal d = new ChamadoDal();
                d.SaveOrUpdate(cd);

                return Json("Chamado cadastrado com sucesso.");

            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        #endregion
    }
}