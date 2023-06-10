using System.Web.Http;

namespace EstudioContable.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            string baseRoute = "estudio-contable";
            
             config.Routes.MapHttpRoute(
                name: "Empleados",
                routeTemplate: baseRoute + "/empleados",
                defaults: new { controllers = "GetEmpleadoById", action = "GetEmpleadoById" }
            );

        }
    }
}