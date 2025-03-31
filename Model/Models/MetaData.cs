using System.ComponentModel;

namespace Models;

public class MetaData : BaseEntity
{
    public DateTime? GeneratedAt
    {
        get => CreatedAt;
        set => CreatedAt = value;
    }

    public decimal Version { get; set; }
    public List<string> Tags { get; set; } = [];
}