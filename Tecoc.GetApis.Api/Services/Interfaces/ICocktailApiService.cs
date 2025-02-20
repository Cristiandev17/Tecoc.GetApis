using Tecoc.GetApis.Api.Models.Responses;

namespace Tecoc.GetApis.Api.Services.Interfaces;

public interface ICocktailApiService
{
    Task<BaseResponse<List<object>>> GetCocktailsByLetterAsync(string letter);
}
