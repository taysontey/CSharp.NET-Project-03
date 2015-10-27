using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Projeto.DAL.Persistence;
using Projeto.Entity.Entities;
using Projeto.Web.Models.Funcionario;
using Projeto.Security.Security;

namespace Projeto.Web.Controllers
{
    public class FuncionarioController : Controller
    {
        public ActionResult Logout()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Cadastro()
        {
            return View();
        }

        #region Metodos AJAX

        public JsonResult Cadastrar(FuncionarioModelCadastro model)
        {
            try
            {
                FuncionarioDal d = new FuncionarioDal();
                if(!d.HasLogin(model.Login))
                { 
                    Funcionario f = new Funcionario();

                    f.Nome = model.Nome;
                    f.Sobrenome = model.Sobrenome;
                    f.Login = model.Login;
                    f.Senha = Criptografia.GetMD5Hash(model.Senha);
                    f.DataCadastro = DateTime.Now;

                    d.SaveOrUpdate(f);

                    return Json("Funcionário cadastrado com sucesso.");
                }
                else
                {
                    return Json("Login indisponivel, tente outro.");
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