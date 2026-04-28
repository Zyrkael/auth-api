namespace auth_api.Entities;

public class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
