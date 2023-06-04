using System.Web.Http;
using App.Controllers;
using App.Usecases;
using Autofac;
using Autofac.Integration.WebApi;

namespace App
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            // Registrar los servicios y sus implementaciones
            builder.RegisterType<GetEmpresasByUsuarioUseCase>().As<IGetEmpresasByUsuarioUseCase>();
            // Construir el contenedor
            var container = builder.Build();
            // Configurar la resolución de dependencias de Autofac
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            
            
            
            config.MapHttpAttributeRoutes();
            
            string baseRoute = "estudio-contable";

            config.Routes.MapHttpRoute(
                name: "Empresas",
                routeTemplate: baseRoute + "/empresas",
                defaults: new { controllers = "GetEmpresasByUsuarioController", action = "GetEmpresasByUsuario" }
            );
            
        }
    }
}