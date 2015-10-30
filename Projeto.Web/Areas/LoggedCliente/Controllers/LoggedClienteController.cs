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

                var list = d.FindById(model.IdChamado);

                return Json(list);
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

                d.DeleteById(model.IdChamado);

                return Json("Chamado excluído.");
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
                if (model.NewSenha.Equals(model.ConfirmSenha))
                {
                    if (d.CheckPassword(Criptografia.GetMD5Hash(model.OldSenha)))
                    {
                        d.UpdatePassword(c.IdUsuario, Criptografia.GetMD5Hash(model.NewSenha));
                        return Json("Senha atualizada.");
                    }
                    else
                    {
                        return Json("Senha atual incorreta.");
                    }
                }
                else
                {
                    return Json("As senhas não correspondem.");
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