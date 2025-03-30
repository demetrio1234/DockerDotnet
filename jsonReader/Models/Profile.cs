namespace jsonReader.Models;
public class Profile
{
    public int Age { get; set; }
    public bool Verified { get; set; }
    public List<Preference> Preferences { get; set; } = [];
}