using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Projeto.Web.Models.Usuario;
using Projeto.Entity.Entities;
using Projeto.DAL.Persistence;
using Projeto.Web.Areas.LoggedFuncionario.Models;
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
        public ActionResult ListaChamado()
        {
            return View();
        }

        [Authorize]
        public ActionResult NovaSenha()
        {
            return View();
        }

        #region Metodos AJAX

        public JsonResult ListarChamado()
        {
            try
            {
                Funcionario f = (Funcionario)Session["funcionariologado"];

                ChamadoDal d = new ChamadoDal();

                List<Chamado> lista = d.FindAllChamado();

                List<Chamado> list = new List<Chamado>();

                foreach(Chamado ch in lista)
                {

                    Chamado c = new Chamado();

                    c.IdChamado = ch.IdChamado;
                    c.Assunto = ch.Assunto;
                    c.Descricao = ch.Descricao;
                    c.Situacao = ch.Situacao;
                    c.DataAbertura = ch.DataAbertura;

                    c.Cliente = new Cliente();
                    c.Cliente.Nome = ch.Cliente.Nome;

                    list.Add(c);
                }
                
                return Json(list);

            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        #endregion
    }
}