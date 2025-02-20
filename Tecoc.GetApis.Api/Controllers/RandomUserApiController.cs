
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tecoc.GetApis.Api.Models.Responses;
using Tecoc.GetApis.Api.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tecoc.GetApis.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RandomUserApiController(IRandomUserApiService _randomUserApiService) : ControllerBase
    {
        // GET api/<RandomUserApiController>/i
        [HttpGet]
        public async Task<ActionResult<BaseResponse<object>>> Get()
        {
            var users = await _randomUserApiService.GetUsersAsync(10);

            if (users.IsSuccess)
            {
                return Ok(users);
            }

            return NotFound(users);
        }
    }
}
