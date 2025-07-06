namespace Model.Models;

public class Notification : BaseEntity
{
    public bool? Email { get; set; }
    public bool? SMS { get; set; }
    public bool? Push { get; set; }
}