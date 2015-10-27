using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Web.Models.Usuario
{
    public class UsuarioModelLogin
    {
        [Required(ErrorMessage = "Erro, Informe o Login.")]
        [Display(Name = "Login:")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Erro, Informe a Senha.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha:")]
        public string Senha { get; set; }

        [Display(Name = "Manter conectado.")]
        public bool ManterConectado { get; set; }
    }
}