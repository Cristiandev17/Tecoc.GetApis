using Microsoft.AspNetCore.Mvc;
using Tecoc.GetApis.Api.Models.Responses;
using Tecoc.GetApis.Api.Services;
using Tecoc.GetApis.Api.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tecoc.GetApis.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CocktailApiController(ICocktailApiService _cocktailApiService) : ControllerBase
    {
        // GET: api/<CocktailApiController>
        [HttpGet("{letter}")]
        public async Task<ActionResult<BaseResponse<object>>> Get([FromQuery] string letter)
        {
            var cocktails = await _cocktailApiService.GetCocktailsByLetterAsync(letter);

            if (cocktails.IsSuccess)
            {
                return Ok(cocktails);
            }

            return NotFound(cocktails);
        }
    }
}
