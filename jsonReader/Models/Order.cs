namespace jsonReader.Models
{
    public class Order : BaseEntity
    {
        public new DateTime CreatedAt { get; set; }
        public DateTime PlacedAt
        {
            get => CreatedAt;
            set => CreatedAt = value;
        }
        public List<Item> Items = [];
    }
}