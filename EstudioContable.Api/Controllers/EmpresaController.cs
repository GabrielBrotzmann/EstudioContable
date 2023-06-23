using System.Web.Http;
using EstudioContable.Negocio;

namespace EstudioContable.Api.Controllers
{
    public class EmpresaController : ApiController
    {
        private readonly IEmpresaNegocio _empresaNegocio;

        public EmpresaController(IEmpresaNegocio empresaNegocio)
        {
            _empresaNegocio = empresaNegocio;
        }

        [HttpGet]
        [Route("estudio-contable/empresas")]
        public IHttpActionResult GetEmpresasByUsuario([FromUri] int? idUsuario)
        {
            if (!idUsuario.HasValue)
            {
                return BadRequest("El parametro idUsuario es obligatorio");
            }
            if (idUsuario <= 0)
            {
                return BadRequest("idUsuario invalido");
            }
            return Ok(_empresaNegocio); 
        }

    }
}