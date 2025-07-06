namespace Model.Extensions;

public static class EnumExtension
{
    public static string GetCorrespondentName(int enumerator, Type type)
    {
        foreach (var name in Enum.GetNames(type))
        {
            if (string.Equals(name, enumerator!.ToString(), StringComparison.OrdinalIgnoreCase))
                return name;
        }
        return string.Empty;
    }
}