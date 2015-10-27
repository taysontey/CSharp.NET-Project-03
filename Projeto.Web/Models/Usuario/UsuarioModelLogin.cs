using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Web.Models.Usuario
{
    public class UsuarioModelLogin
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool ManterConectado { get; set; }
    }
}