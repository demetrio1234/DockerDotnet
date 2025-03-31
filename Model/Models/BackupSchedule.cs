namespace Models;
public class BackupSchedule
{
    public string Frequency { get; set; } = "yearly";//TODO: replace with a constant string from the Constants class 
    public string Day { get; set; } = "Sunday";//TODO: replace with a constant string from the Constants class
    public TimeOnly Time { get; set; }
}
