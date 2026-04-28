namespace auth_api.Dtos.Common;

public class BaseResponse<T>
{
    public int Status { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }

    public static BaseResponse<T> Success(T? data, string message = "Thành công", int status = 0)
    {
        return new BaseResponse<T> { Status = status, Message = message, Data = data };
    }

    public static BaseResponse<T> Failure(string message, int status = 1)
    {
        return new BaseResponse<T> { Status = status, Message = message, Data = default };
    }
}
