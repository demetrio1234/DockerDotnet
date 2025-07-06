namespace Model.Models;

public class User : BaseEntity
{
    private string email = string.Empty;
    public string Email
    {
        get => email;
        set => email = value;
    }

    public Profile? Profile { get; set; }
    public List<Order> Orders { get; set; } = [];
    public List<Setting> Settings { get; set; } = [];
}