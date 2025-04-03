using System.Text.Json.Serialization;

namespace Model.Models;
public class Order : BaseEntity
{
    public new string Id { get; set; } = string.Empty;

    private DateTime? _createdAt;
    [JsonPropertyName("PlacedAtDate")]
    public override DateTime? CreatedAt
    {
        get => _createdAt;
        set => _createdAt = value;
    }
    public List<Item>? Items { get; set; }
}