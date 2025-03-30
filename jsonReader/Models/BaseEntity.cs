namespace jsonReader.Models;
public class BaseEntity
{
    public ulong Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public virtual DateTime CreatedAt { get; set; }
    public virtual DateTime LastModified { get; set; }
}