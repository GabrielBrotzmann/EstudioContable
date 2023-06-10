using System.Web.Http;

namespace EstudioContable.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DependencyContainer.RegisterDependencies();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}