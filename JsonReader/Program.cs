using JsonReader.Converters;
using Model.Models;
using System.Text.Json;

JsonSerializerOptions jsonOptions = new(JsonSerializerDefaults.Web);
jsonOptions.Converters.Add(new DateTimeOffsetConverterUsingDateTimeParse());

string folderName = "DummyJsonData";//TODO: relocate the string into a constant container class

string path = RecurseTillFound(Directory.GetCurrentDirectory(), folderName, true);
IEnumerable<string> files = Directory.EnumerateFileSystemEntries(path);
List<byte[]> bytes = [.. files.Select(File.ReadAllBytes)];
List<JsonDocument> jsonDocs = [.. bytes.Select(byteArray => JsonDocument.Parse(byteArray))];

CustomerData? customerData = JsonSerializer.Deserialize<CustomerData>(jsonDocs[0].RootElement, jsonOptions);

if (customerData is not null)
{
    Console.WriteLine(customerData.MetaData);
    Console.WriteLine(customerData.Settings);
    Console.WriteLine(customerData.User);
}

static string RecurseTillFound(string currentFolder, string folderLookingFor, bool up)
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