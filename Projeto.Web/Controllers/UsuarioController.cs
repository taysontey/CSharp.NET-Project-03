using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Projeto.Web.Models.Usuario;
using Projeto.DAL.Persistence;
using Projeto.Entity.Entities;
using Projeto.Security.Security;

namespace Projeto.Web.Controllers
{
    public class UsuarioController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AutenticarUsuario(UsuarioModelLogin model)
        {
            try
            {
                FuncionarioDal d = new FuncionarioDal();
                Funcionario f = d.Authenticate(model.Login, Criptografia.GetMD5Hash(model.Senha));

                ClienteDal cd = new ClienteDal();
                Cliente c = cd.Authenticate(model.Login, Criptografia.GetMD5Hash(model.Senha));

                if (f != null)
                {

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(f.Login, model.ManterConectado, 5);

                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                    FormsAuthentication.Encrypt(ticket));

                    Response.Cookies.Add(cookie);

                    Session.Add("funcionariologado", f);

                    return Json(new
                        {
                            redirectUrl = Url.Action("Index", "Home", new { area = "LoggedFuncionario" }),
                            isRedirect = true
                        });

                }

                if (c != null)
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(c.Login, model.ManterConectado, 5);

                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                    FormsAuthentication.Encrypt(ticket));

                    Response.Cookies.Add(cookie);

                    Session.Add("clientelogado", c);

                    return Json(new
                    {
                        redirectUrl = Url.Action("Index", "Home", new { area = "LoggedCliente" }),
                        isRedirect = true
                    });
                }
                else
                {
                    return Json("Login ou Senha incorretos, tente novamente.");
                }

            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
    }
}