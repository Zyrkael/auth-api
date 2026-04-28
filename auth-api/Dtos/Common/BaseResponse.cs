namespace auth_api.Dtos.Common;

public class BaseResponse<T>
{
    public int Status { get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }
}
