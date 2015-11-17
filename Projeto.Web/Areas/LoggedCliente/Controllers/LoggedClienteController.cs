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
using Projeto.Security.Security;


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
        public ActionResult CadastroChamado()
        {
            return View();
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

        #region Metodos AJAX(Chamado)

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

        public JsonResult EdicaoChamado(ChamadoModelEdicao model)
        {
            try
            {
                Cliente c = (Cliente)Session["clientelogado"];

                ChamadoDal d = new ChamadoDal();

                Chamado chamado = d.FindById(model.IdChamado);

                model.Assunto = chamado.Assunto;
                model.Descricao = chamado.Descricao;

                return Json(model);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult EditarChamado(ChamadoModelEdicao model)
        {
            try
            {
                Cliente c = (Cliente)Session["clientelogado"];

                ChamadoDal d = new ChamadoDal();

                Chamado chamado = d.FindById(model.IdChamado);

                if (chamado.Situacao.Equals("Aberto"))
                {
                    chamado.Assunto = model.Assunto;
                    chamado.Descricao = model.Descricao;

                    d.SaveOrUpdate(chamado);

                    return Json("Chamado Atualizado.");
                }
                else
                {
                    return Json("Chamado não pode ser alterado, o mesmo já se encontra fechado.");
                }

            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult ListarChamado()
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

        public JsonResult ExcluirChamado(ChamadoModelDelete model)
        {
            try
            {
                Cliente c = (Cliente)Session["clientelogado"];

                ChamadoDal d = new ChamadoDal();
                Chamado chamado = d.FindById(model.IdChamado);

                if (chamado.Situacao.Equals("Aberto"))
                {
                    d.Delete(chamado);

                    return Json("Chamado excluído.");
                }
                else
                {
                    return Json("Chamado não pode ser excluído, o mesmo já se encontra fechado.");
                }

            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        #endregion

        #region Metodos AJAX(Cliente)

        public JsonResult AlterarSenha(ClienteModelSenha model)
        {
            try
            {
                Cliente c = (Cliente)Session["clientelogado"];

                ClienteDal d = new ClienteDal();


                if (d.CheckPassword(Criptografia.GetMD5Hash(model.OldSenha)))
                {
                    c = d.FindById(c.IdUsuario);
                    c.Senha = Criptografia.GetMD5Hash(model.NewSenha);

                    d.SaveOrUpdate(c);

                    return Json("Senha atualizada.");
                }
                else
                {
                    return Json("Senha Atual incorreta.");
                }
            }

            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        #endregion
    }
}