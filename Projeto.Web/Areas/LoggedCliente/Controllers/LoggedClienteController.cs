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

        [Authorize]
        public ActionResult Lista()
        {
            return View();
        }

        #region Metodos AJAX

        public JsonResult AbrirChamado(ChamadoModelCadastro model)
        {
            try
            {
                Cliente c = (Cliente)Session["clientelogado"];
                
                Chamado ch = new Chamado();
                ch.DataAbertura = DateTime.Now;
                ch.Assunto = model.Assunto;
                ch.Descricao = model.Descricao;
                ch.Situacao = "Aberto";
                ch.Cliente = c;

                ChamadoDal d = new ChamadoDal();
                d.SaveOrUpdate(ch);

                return Json("Chamado cadastrado com sucesso.");

            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult Edicao(ChamadoModelEdicao model)
        {
            try
            {
                Cliente c = (Cliente)Session["clientelogado"];

                ChamadoDal d = new ChamadoDal();

                var list = d.FindById(model.IdChamado);

                return Json(list);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult Editar(ChamadoModelEdicao model)
        {
            try
            {
                Cliente c = (Cliente)Session["clientelogado"];

                Chamado ch = new Chamado();
                ch.IdChamado = model.IdChamado;
                ch.Assunto = model.Assunto;
                ch.Descricao = model.Descricao;
                
                ChamadoDal d = new ChamadoDal();

                d.Update(ch);

                return Json("Chamado Atualizado.");
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult Listar()
        {
            try
            {
                Cliente c = (Cliente)Session["clientelogado"];

                ChamadoDal d = new ChamadoDal();

                var list = d.FindAllByCliente(c);

                return Json(list);
                
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult Excluir(ChamadoModelDelete model)
        {
            try
            {
                Cliente c = (Cliente)Session["clientelogado"];

                ChamadoDal d = new ChamadoDal();

                d.DeleteById(model.IdChamado);
                
                return Json("Chamado excluído.");
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        #endregion
    }
}