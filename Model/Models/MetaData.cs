using System.Text.Json.Serialization;

namespace Model.Models;

public class MetaData : BaseEntity
{
    private DateTime? _createdAt;

    [JsonPropertyName("GeneratedAt")]
    public override DateTime? CreatedAt
    {
        get => _createdAt;
        set
        {
            _createdAt = value;
        }
    }
    public decimal Version { get; set; }
    public List<string> Tags { get; set; } = [];
}