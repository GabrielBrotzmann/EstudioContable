using System.Web.Http;
using EstudioContable.Negocio;

namespace EstudioContable.Api.Controllers
{
    public class EmpleadoController : ApiController
    {
        private readonly IEmpleadoNegocio _empleadoNegocio;

        public EmpleadoController()
        {
            _empleadoNegocio = DependencyContainer.EmpleadoNegocio;
        }

        [HttpGet]
        [Route("estudio-contable/empleados/{id}")]
        public IHttpActionResult GetEmpleadoById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("idUsuario invalido");
            }
            return Ok(_empleadoNegocio.GetByIdEmpleado(id)); 
        }
    }
}