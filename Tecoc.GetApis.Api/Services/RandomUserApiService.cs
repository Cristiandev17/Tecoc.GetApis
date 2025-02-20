using RestSharp;
using Tecoc.GetApis.Api.Models.Responses;
using Tecoc.GetApis.Api.Services.Interfaces;
using Tecoc.GetApis.Api.Utilities;

namespace Tecoc.GetApis.Api.Services;

public class RandomUserApiService : IRandomUserApiService
{
    public async Task<BaseResponse<List<UserResponse>>> GetUsersAsync(int quantity)
    {
        var client = new RestClient();
        var result = await client.GetAsync<ResultApiUsersResponse>($"{Constans.UrlRandomUser}{quantity}");
        return new BaseResponse<List<UserResponse>>(result.results) ;
    }
}
