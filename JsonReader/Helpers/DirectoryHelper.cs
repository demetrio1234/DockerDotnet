namespace JsonReader.Helpers;

public static class DirectoryHelper
{
    public static string RecurseTillFound(string currentFolder, string folderLookingFor, bool up)
    {
        string currentDirectory = Directory.Exists(currentFolder)
            ? currentFolder
            : Path.GetFullPath(Path.Combine(currentFolder, ".."));

        if (string.Equals(currentDirectory.Split(Path.DirectorySeparatorChar).Last(), folderLookingFor))
        {
            return currentDirectory;
        }

        //if any of the folders inside the current folder matches the folder we are looking for
        IEnumerable<string> directories = Directory
            .EnumerateDirectories(currentDirectory)
            .Where(d => string.Equals(d.Split(Path.DirectorySeparatorChar).Last(), folderLookingFor));

        if (directories.Any())
        {
            return directories.First();
        }

        if (up)
        {
            DirectoryInfo? parentDirectory = Directory.GetParent(currentDirectory);
            return parentDirectory is null ? string.Empty : RecurseTillFound(parentDirectory.FullName, folderLookingFor, up);
        }

        return string.Empty;
    }
}