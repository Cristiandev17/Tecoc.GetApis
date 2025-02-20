using RestSharp;
using Tecoc.GetApis.Api.Models.Responses;
using Tecoc.GetApis.Api.Services.Interfaces;
using Tecoc.GetApis.Api.Utilities;

namespace Tecoc.GetApis.Api.Services;

public class CocktailApiService : ICocktailApiService
{
    public async Task<BaseResponse<List<object>>> GetCocktailsByLetterAsync(string letter)
    {
        var client = new RestClient();
        var result = await client.GetAsync<List<object>>($"{Constans.UrlTheCocktail}{letter}");
        return new BaseResponse<List<object>>(result);
    }
}
