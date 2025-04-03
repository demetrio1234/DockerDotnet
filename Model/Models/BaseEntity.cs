using System.Runtime.InteropServices.Marshalling;

namespace Model.Models;
public class BaseEntity
{
    public ulong Id { get; set; }
    public string? Name { get; set; }
    public virtual DateTime? CreatedAt { get; set; }
    private DateTime? lastModified;
    public virtual DateTime? LastModified
    {
        get => lastModified is not null ? lastModified : CreatedAt;
        set => lastModified = value;
    }
}