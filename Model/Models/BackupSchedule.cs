using Model.Enums;
using Model.Extensions;

namespace Model.Models;

public class BackupSchedule : BaseEntity
{
    public string Frequency
    {
        //        get => EnumExtension.GetCorrespondentName(_frequency, typeof(Frequency));
        //        set => _frequency = ConvertFrequencyFromStringToInt(value);
        get; set;
    } = Enum.GetName(Enums.Frequency.Year)!;

    //private int _frequency { get; set; } = (int)Enums.Frequency.Year;

    public string Day
    {
        //        get => EnumExtension.GetCorrespondentName(_day, typeof(WeekDays));
        //        set => _day = ConvertWeekDayFromStringToInt(value);
        get; set;
    } = Enum.GetName(WeekDays.Sunday)!;

    //private int _day { get; set; } = (int)WeekDays.Sunday;
    public TimeOnly Time { get; set; }

    private static int ConvertFrequencyFromStringToInt(string val)
    {
        if (string.IsNullOrWhiteSpace(val))
            return (int)Enums.Frequency.Year;

        foreach (var name in Enum.GetNames(typeof(Frequency)))
        {
            if (string.Equals(name, val, StringComparison.OrdinalIgnoreCase))
                return (int)Enum.Parse(typeof(Frequency), name);
        }

        // Try fuzzy match for minor typos (Levenshtein distance <= 1)
        foreach (var name in Enum.GetNames(typeof(Frequency)))
        {
            if (LevenshteinDistance(name.ToLower(), val.ToLower()) <= 1)
                return (int)Enum.Parse(typeof(Frequency), name);
        }

        return (int)Enums.Frequency.Year;
    }

    private static int ConvertWeekDayFromStringToInt(string val)
    {
        if (string.IsNullOrWhiteSpace(val))
            return (int)WeekDays.Sunday;

        foreach (var name in Enum.GetNames(typeof(WeekDays)))
        {
            if (string.Equals(name, val, StringComparison.OrdinalIgnoreCase))
                return (int)Enum.Parse(typeof(WeekDays), name);
        }

        // Try fuzzy match for minor typos (Levenshtein distance <= 1)
        foreach (var name in Enum.GetNames(typeof(WeekDays)))
        {
            if (LevenshteinDistance(name.ToLower(), val.ToLower()) <= 1)
                return (int)Enum.Parse(typeof(WeekDays), name);
        }

        return (int)WeekDays.Sunday;
    }

    // Simple Levenshtein distance implementation
    private static int LevenshteinDistance(string s, string t)
    {
        if (string.IsNullOrEmpty(s)) return t.Length;
        if (string.IsNullOrEmpty(t)) return s.Length;

        int[,] d = new int[s.Length + 1, t.Length + 1];

        for (int i = 0; i <= s.Length; i++) d[i, 0] = i;
        for (int j = 0; j <= t.Length; j++) d[0, j] = j;

        for (int i = 1; i <= s.Length; i++)
        {
            for (int j = 1; j <= t.Length; j++)
            {
                int cost = (s[i - 1] == t[j - 1]) ? 0 : 1;
                d[i, j] = Math.Min(
                    Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                    d[i - 1, j - 1] + cost);
            }
        }
        return d[s.Length, t.Length];
    }
}