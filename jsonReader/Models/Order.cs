namespace jsonReader.Models
{
    public class Order : BaseEntity
    {
        public new string Id { get; set; } = string.Empty;
        public new DateTime CreatedAt { get; set; }
        public DateTime PlacedAtDate
        {
            get => CreatedAt;
            set => CreatedAt = value;
        }
        public List<Item>? Items { get; set; }
    }
}