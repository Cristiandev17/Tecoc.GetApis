using Tecoc.GetApis.Api.Models.Responses;

namespace Tecoc.GetApis.Api.Services.Interfaces;

public interface IRandomUserApiService
{
    Task<BaseResponse<List<UserResponse>>> GetUsersAsync(int quantity);
}
