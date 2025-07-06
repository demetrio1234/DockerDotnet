namespace Model.Models;

public class Settings : BaseEntity
{
    public bool AutoBackup { get; set; }
    public BackupSchedule BackupSchedule { get; set; } = new();
    public DateTime? LastBackup { get; set; }
}