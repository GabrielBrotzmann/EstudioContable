using System.Web.Http;

namespace EstudioContable.Api.Controllers
{
    public class HealthController : ApiController
    {

        [HttpGet]
        [Route("")]
        public IHttpActionResult Health()
        {
            return Ok("Hello World!");
        }
    }
}