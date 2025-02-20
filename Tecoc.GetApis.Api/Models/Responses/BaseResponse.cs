namespace Tecoc.GetApis.Api.Models.Responses;

public class BaseResponse<T>(T data, string message = "", bool isSuccess = false)
{
    public bool IsSuccess => isSuccess;

    public string Message => message;

    public T Data => data;
}
