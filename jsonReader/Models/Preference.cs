namespace jsonReader.Models;
public class Preference
{
    public string Theme { get; set; } = string.Empty;
    public string Language { get; set; } = "de-DE"; //TODO: place it in the constant class
    public Notification Nofitications = new();
}