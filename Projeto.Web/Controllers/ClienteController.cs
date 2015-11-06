using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.DAL.Persistence;
using Projeto.Entity.Entities;
using Projeto.Web.Models.Cliente;
using Projeto.Security.Security;

namespace Projeto.Web.Controllers
{
    public class ClienteController : Controller
    {      
        [AllowAnonymous]
        public ActionResult Cadastro()
        {
            return View();
        }

        #region Metodos AJAX

        public JsonResult Cadastrar(ClienteModelCadastro model)
        {
            try
            {
                ClienteDal d = new ClienteDal();

                if (!d.HasLogin(model.Login))
                {
                    //Verificar se é possivel melhorar essa parte + tarde

                    Cliente c = new Cliente();
                    
                    c.Nome = model.Nome;
                    c.Sobrenome = model.Sobrenome;
                    c.Login = model.Login;
                    c.Senha = Criptografia.GetMD5Hash(model.Senha);
                    c.DataNascimento = model.DataNascimento;
                    c.Sexo = model.Sexo;

                    d.SaveOrUpdate(c);

                    c.Endereco = new Endereco();

                    c.Endereco.Logradouro = model.Logradouro;
                    c.Endereco.Bairro = model.Bairro;
                    c.Endereco.Cidade = model.Cidade;
                    c.Endereco.Estado = model.Estado;
                    c.Endereco.CEP = model.CEP;
                    c.Endereco.Cliente = c;

                    Telefone t1 = new Telefone();
                    
                    t1.Numero = model.Numero1;
                    t1.Tipo = model.Tipo1;
                    t1.Cliente = c;

                    Telefone t2 = new Telefone();

                    t2.Numero = model.Numero2;
                    t2.Tipo = model.Tipo2;
                    t2.Cliente = c;

                    c.Telefones = new List<Telefone>();
                    c.Telefones.Add(t1);
                    c.Telefones.Add(t2);
                    
                    d.SaveOrUpdate(c);

                    return Json("Cliente cadastrado com sucesso.");
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