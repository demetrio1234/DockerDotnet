namespace Model.Models;

public class Setting
{
    public bool AutoBackup { get; set; }
    public BackupSchedule BackupSchedule { get; set; } = new();
    public DateTime? LastBackup { get; set; }
}