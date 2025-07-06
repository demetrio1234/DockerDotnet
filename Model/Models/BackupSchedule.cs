using Model.Enums;

namespace Model.Models;

public class BackupSchedule : BaseEntity
{
    public int Frequency { get; set; } = (int)Enums.Frequency.Year;
    public int Day { get; set; } = (int)WeekDays.Sunday;
    public TimeOnly Time { get; set; }
}
