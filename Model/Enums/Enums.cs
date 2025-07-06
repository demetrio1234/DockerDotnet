namespace Model.Enums;

public enum Frequency
{
    Second = 0,
    Minute = 10,
    Hour = 20,
    Day = 30,
    Week = 40,
    Month = 50,
    Year = 60
}

public enum WeekDays
{
    Sunday = 0,
    Monday = 1,
    Tuesday = 2,
    Wednesday = 3,
    Thursday = 4,
    Friday = 5,
    Saturday = 6
}

public static class FrequencyExtensions
{
    public static Frequency ClampToMax(this int value)
    {
        int maxValue = (int)Frequency.Year;
        if (value >= maxValue)
            return Frequency.Year;

        foreach (Frequency freq in Enum.GetValues(typeof(Frequency)))
        {
            if ((int)freq == value)
                return freq;
        }

        // Optionally, handle values less than the minimum or not matching any enum value
        return Frequency.Second;
    }
}

public static class WeekDaysExtensions
{
    public static WeekDays ClampToMax(this int value)
    {
        int maxValue = (int)WeekDays.Saturday;
        if (value >= maxValue)
            return WeekDays.Saturday;

        foreach (WeekDays day in Enum.GetValues(typeof(WeekDays)))
        {
            if ((int)day == value)
                return day;
        }

        // Optionally, handle values less than the minimum or not matching any enum value
        return WeekDays.Sunday;
    }
}