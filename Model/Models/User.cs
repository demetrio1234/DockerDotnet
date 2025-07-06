namespace Model.Models;

public class User : BaseEntity
{
    public string Email { get; set; } = string.Empty;
    public Profile? Profile { get; set; }
    public IList<Order> Orders { get; set; } = [];
}