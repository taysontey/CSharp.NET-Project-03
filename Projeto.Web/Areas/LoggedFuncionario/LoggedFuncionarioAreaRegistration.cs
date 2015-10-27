using System.Web.Mvc;

namespace Projeto.Web.Areas.LoggedFuncionario
{
    public class LoggedFuncionarioAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "LoggedFuncionario";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "LoggedFuncionario_default",
                "LoggedFuncionario/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}