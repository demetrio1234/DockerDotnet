using System.Text.Json;
using JsonReader.Converters;
using Model.Models;

JsonSerializerOptions jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
jsonOptions.Converters.Add(new DateTimeOffsetConverterUsingDateTimeParse());

var folderName = "DummyJsonData";//TODO: relocate the string into a constant container class
var currentDirectory = Directory.Exists($".{Path.AltDirectorySeparatorChar}{folderName}")
                        ? $".{Path.AltDirectorySeparatorChar}"
                        : $"..{Path.AltDirectorySeparatorChar}";


var path = Path.Combine([currentDirectory, folderName]);
var files = Directory.EnumerateFileSystemEntries(path);
List<byte[]> bytes = [.. files.Select(File.ReadAllBytes)];
List<JsonDocument> jsonDocs = [.. bytes.Select(byteArray => JsonDocument.Parse(byteArray))];

var customerData = JsonSerializer.Deserialize<CustomerData>(jsonDocs[0].RootElement, jsonOptions);

if (customerData is not null)
{
    Console.WriteLine(customerData.MetaData);
    Console.WriteLine(customerData.Settings);
    Console.WriteLine(customerData.User);
}

static void EnumerateFileSystemEntries(DirectoryInfo? p)
{
    IEnumerable<string> en = p is not null && p.Exists
        ? Directory.EnumerateFileSystemEntries(p.FullName) :
        [];

    foreach (var item in en)
        Console.WriteLine(item);
}