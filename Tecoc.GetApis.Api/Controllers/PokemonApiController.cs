using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tecoc.GetApis.Api.Models.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tecoc.GetApis.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PokemonApiController : ControllerBase
    {
        // GET: api/<PokemonApiController>
        [HttpGet]
        public async Task<ActionResult<BaseResponse<object>>> Get()
        {
            return Ok();
        }
    }
}
