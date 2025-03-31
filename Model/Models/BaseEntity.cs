namespace Models;
public class BaseEntity
{
    public ulong Id { get; set; }
    public string? Name { get; set; }
    public virtual DateTime? CreatedAt { get; set; }
    public virtual DateTime? LastModified { get; set; }
}