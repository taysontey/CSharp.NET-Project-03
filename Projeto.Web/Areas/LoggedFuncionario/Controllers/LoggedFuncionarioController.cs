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
        public ActionResult ListaChamado()
        {
            return View();
        }

        [Authorize]
        public ActionResult ConsultaChamado()
        {
            return View();
        }

        [Authorize]
        public ActionResult NovaSenha()
        {
            return View();
        }

        #region Metodos AJAX (Chamado)

        public JsonResult EdicaoChamado(ChamadoModelEdicao model)
        {
            try
            {
                Funcionario f = (Funcionario)Session["funcionariologado"];

                ChamadoDal d = new ChamadoDal();

                Chamado chamado = d.FindById(model.IdChamado);

                Chamado ch = new Chamado();

                ch.IdChamado = chamado.IdChamado;
                ch.Assunto = chamado.Assunto;
                ch.Descricao = chamado.Descricao;
                ch.Solucao = chamado.Solucao;

                return Json(ch, JsonRequestBehavior.AllowGet);
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
                Funcionario f = (Funcionario)Session["funcionariologado"];

                ChamadoDal d = new ChamadoDal();

                Chamado chamado = d.FindById(model.IdChamado);

                if(chamado.Situacao == "Aberto")
                {
                    chamado.Solucao = model.Solucao;
                    chamado.Situacao = "Fechado";
                    chamado.DataFechamento = DateTime.Now;
                    chamado.Funcionario = f;

                    d.SaveOrUpdate(chamado);

                    return Json("Chamado Atualizado.");
                }
                else
                {
                    return Json("Esse chamado já foi fechado.");
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
                Funcionario f = (Funcionario)Session["funcionariologado"];

                ChamadoDal d = new ChamadoDal();

                List<Chamado> lista = d.FindAll();

                List<Chamado> list = new List<Chamado>();

                foreach(Chamado chamado in lista)
                {
                    Chamado ch = new Chamado();

                    ch.IdChamado = chamado.IdChamado;
                    ch.Assunto = chamado.Assunto;
                    ch.Situacao = chamado.Situacao;
                    ch.DataAbertura = chamado.DataAbertura;

                    ch.Cliente = new Cliente();
                    ch.Cliente.Nome = chamado.Cliente.Nome;

                    list.Add(ch);
                }

                return Json(list);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        #endregion

        #region Consultas (Chamado)

        public JsonResult ConsultarChamado_ID(ChamadoModelResultado model)
        {
            try
            {
                ChamadoDal d = new ChamadoDal();

                Chamado chamado = d.FindById(model.IdChamado);

                model.IdChamado = chamado.IdChamado;
                model.Assunto = chamado.Assunto;
                model.Situacao = chamado.Situacao;
                model.DataAbertura = chamado.DataAbertura;
                model.Cliente_Nome = chamado.Cliente.Nome;

                List<ChamadoModelResultado> list = new List<ChamadoModelResultado>();
                list.Add(model);

                return Json(list);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult ConsultarChamado_Situacao(ChamadoModelResultado model)
        {
            try
            {
                ChamadoDal d = new ChamadoDal();
                
                List<Chamado> lista = d.FindAllBySituacao(model.Situacao);

                List<ChamadoModelResultado> list = new List<ChamadoModelResultado>();

                foreach(Chamado chamado in lista)
                {
                    model.IdChamado = chamado.IdChamado;
                    model.Assunto = chamado.Assunto;
                    model.Situacao = chamado.Situacao;
                    model.DataAbertura = chamado.DataAbertura;
                    model.Cliente_Nome = chamado.Cliente.Nome;

                    list.Add(model);
                }

                return Json(list);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult ConsultarChamado_DataAbertura(ChamadoModelResultado model)
        {
            try
            {
                ChamadoDal d = new ChamadoDal();

                List<Chamado> lista = d.FindAllByDataAbertura(model.DataInicial, model.DataFinal);

                List<ChamadoModelResultado> list = new List<ChamadoModelResultado>();

                foreach (Chamado chamado in lista)
                {
                    model.IdChamado = chamado.IdChamado;
                    model.Assunto = chamado.Assunto;
                    model.Situacao = chamado.Situacao;
                    model.DataAbertura = chamado.DataAbertura;
                    model.Cliente_Nome = chamado.Cliente.Nome;

                    list.Add(model);
                }

                return Json(list);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        #endregion

        #region Metodos AJAX (Funcionario)

        public JsonResult AlterarSenha(FuncionarioModelSenha model)
        {
            try
            {
                Funcionario f = (Funcionario)Session["funcionariologado"];

                FuncionarioDal d = new FuncionarioDal();

                if (model.NewSenha.Equals(model.ConfirmSenha))
                {
                    if (d.CheckPassword(Criptografia.GetMD5Hash(model.OldSenha)))
                    {
                        f = d.FindById(f.IdUsuario);
                        f.Senha = Criptografia.GetMD5Hash(model.NewSenha);

                        d.SaveOrUpdate(f);

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