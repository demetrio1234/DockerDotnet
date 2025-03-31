namespace Models;
public class Preference
{
    public string Theme { get; set; } = string.Empty;
    public string? Language { get; set; }
    public Notification? Nofitications { get; set; } = new();
}