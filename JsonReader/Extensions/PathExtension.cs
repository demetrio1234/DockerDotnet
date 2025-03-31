public static class PathExtensions
{
    public static string GetRelativePath(this string absolutePath, string basePath)
    {
        if (string.IsNullOrEmpty(absolutePath) || string.IsNullOrEmpty(basePath))
            throw new ArgumentException("Both paths must be provided.", $"AbsolutePath: {nameof(absolutePath)} \n BasePath: {nameof(basePath)}");

        var absoluteDirectory = Path.GetFullPath(absolutePath).TrimEnd(Path.DirectorySeparatorChar);
        var basePathDirectory = Path.GetFullPath(basePath).TrimEnd(Path.DirectorySeparatorChar);

        // Convert both to full paths starting from the same root directory for comparison
        var commonRoot = GetCommonPath(absoluteDirectory, basePathDirectory);

        if (commonRoot == null)
            throw new ArgumentException("The provided paths do not share a common root.", $"AbsolutePath: {nameof(absolutePath)} \n BasePath: {nameof(basePath)}");

        // Construct relative path
        return absoluteDirectory.Substring(commonRoot.Length + 1).TrimEnd(Path.DirectorySeparatorChar);
    }


    private static string GetCommonPath(string path1, string path2)
    {
        var parts1 = path1.Split(Path.DirectorySeparatorChar);
        var parts2 = path2.Split(Path.DirectorySeparatorChar);
        var commonParts = new System.Collections.Generic.List<string>();

        for (int i = 0; i < Math.Min(parts1.Length, parts2.Length); i++)
        {
            if (parts1[i].Equals(parts2[i], StringComparison.OrdinalIgnoreCase))
            {
                commonParts.Add(parts1[i]);
            }
            else
            {
                break;
            }
        }

        return string.Join(Path.DirectorySeparatorChar.ToString(), commonParts);
    }

}