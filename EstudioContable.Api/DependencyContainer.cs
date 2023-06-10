using EstudioContable.AccesoDatos;
using EstudioContable.Negocio;

namespace EstudioContable.Api
{
    public static class DependencyContainer
    {
        public static IEmpleadoNegocio EmpleadoNegocio;

        public static void RegisterDependencies()
        {
            EmpleadoNegocio = new EmpleadoNegocio(new EmpleadoDatos());
        }
    }
}