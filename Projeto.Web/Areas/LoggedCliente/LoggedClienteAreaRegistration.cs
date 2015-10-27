using System.Web.Mvc;

namespace Projeto.Web.Areas.LoggedCliente
{
    public class LoggedClienteAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "LoggedCliente";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "LoggedCliente_default",
                "LoggedCliente/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}