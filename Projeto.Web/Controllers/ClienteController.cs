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

                    d.AddCliente(c);

                    Endereco e = new Endereco();

                    e.Logradouro = model.Logradouro;
                    e.Bairro = model.Bairro;
                    e.Cidade = model.Cidade;
                    e.Estado = model.Estado;
                    e.CEP = model.CEP;
                    e.Cliente = c;

                    c.Endereco = e;

                    Telefone t1 = new Telefone();
                    
                    t1.Numero = model.Numero1;
                    t1.Tipo = model.Tipo1;
                    t1.Cliente = c;

                    Telefone t2 = new Telefone();

                    t2.Numero = model.Numero2;
                    t2.Tipo = model.Tipo2;
                    t2.Cliente = c;

                    List<Telefone> lista = new List<Telefone>();

                    lista.Add(t1);
                    lista.Add(t2);

                    c.Telefones = lista;

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