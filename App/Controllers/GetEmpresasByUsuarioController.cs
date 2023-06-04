using System.Web.Http;
using App.Usecases;

namespace App.Controllers
{
    public class GetEmpresasByUsuarioController : ApiController

    {
        private readonly IGetEmpresasByUsuarioUseCase _getEmpresasByUsuarioUseCase;
        
        public GetEmpresasByUsuarioController(IGetEmpresasByUsuarioUseCase getEmpresasByUsuarioUseCase)
        {
            _getEmpresasByUsuarioUseCase = getEmpresasByUsuarioUseCase;
        }
        
        public GetEmpresasByUsuarioController() { } 

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
            return Ok(_getEmpresasByUsuarioUseCase.Execute(idUsuario.Value)); 
        }

    }
}