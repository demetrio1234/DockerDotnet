namespace Model.Models;

public class Preference : BaseEntity
{
    public string Theme { get; set; } = string.Empty;
    public string? Language { get; set; }
    public Notification? Nofitications { get; set; } = new();
}