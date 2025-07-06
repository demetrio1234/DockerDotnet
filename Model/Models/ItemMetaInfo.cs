namespace Model.Models;

public class ItemMetaInfo : BaseEntity
{
    public string? Color { get; set; }
    public uint? WarrantyMonths { get; set; }
    public uint? Layout { get; set; }
}