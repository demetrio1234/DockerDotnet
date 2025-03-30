namespace jsonReader.Models;
public class User : BaseEntity
{
    public string Email { get; set; } = string.Empty;
    public Profile Profile { get; set; } = new();
    public List<Order> Orders = [];
    public List<Setting> Settings { get; set; } = [];
}