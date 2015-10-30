using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Web.Areas.LoggedCliente.Models
{
    public class ClienteModelSenha
    {
        public string OldSenha { get; set; }
        public string NewSenha { get; set; }
        public string ConfirmSenha { get; set; }
       
    }
}