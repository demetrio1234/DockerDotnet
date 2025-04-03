namespace Model.Models;
public class Item : BaseEntity
{
    public string ProductId { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public uint Quantity { get; set; }
    public MetaData? Meta { get; set; }
}