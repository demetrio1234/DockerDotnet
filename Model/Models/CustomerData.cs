namespace Model.Models;

public class CustomerData : BaseEntity
{
    public User User { get; set; } = new();
    public Setting Settings { get; set; } = new();
    public MetaData MetaData { get; set; } = new();
}