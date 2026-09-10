namespace Countify.Domain.Entities.Auth;

public sealed class Permission
{
    private Permission()
    {
    }

    private Permission(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;

    public static implicit operator string(Permission permission) => permission.Name;

    internal static Permission Create(int id, string name, string description) =>
        new(id, name, description);
}