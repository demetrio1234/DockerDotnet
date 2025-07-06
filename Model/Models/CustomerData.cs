namespace Model.Models;

public class CustomerData : BaseEntity
{
    public User User { get; set; } = new();
    public Settings Settings { get; set; } = new();
    public MetaData MetaData { get; set; } = new();
}