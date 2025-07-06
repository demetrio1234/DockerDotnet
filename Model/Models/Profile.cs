namespace Model.Models;

public class Profile : BaseEntity
{
    public uint Age { get; set; }
    public bool Verified { get; set; }
    public Preference? Preference { get; set; }
}