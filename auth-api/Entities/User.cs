namespace auth_api.Entities;

public class User : BaseEntity
{
    public string UserName { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string Email {get; init;} = string.Empty;
}
