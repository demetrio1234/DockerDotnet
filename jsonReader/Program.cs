using System.Text.Json;
using jsonReader.Converters;
using jsonReader.Models;

var currentDirectory = $".{Path.AltDirectorySeparatorChar}";
var folderName = "DummyJsonData";//TODO: relocate the string into a constant container class
var path = Path.Combine([currentDirectory, folderName]);
var files = Directory.EnumerateFileSystemEntries(path);

Console.WriteLine("Here a list of all json files:");
var bytes = new List<byte[]>() { };
//var jsonDocs = new List<>
foreach (var file in files)
{
    Console.WriteLine(file);
    bytes.Add(await File.ReadAllBytesAsync(file));
}

var jsonDocs = new List<JsonDocument>();
foreach (var byteArray in bytes)
{
    var jsonDoc = JsonDocument.Parse(byteArray);
    jsonDocs.Add(jsonDoc);
}
var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
jsonOptions.Converters.Add(new DateTimeOffsetConverterUsingDateTimeParse());
var customerData = JsonSerializer.Deserialize<CustomerData>(jsonDocs[0].RootElement, jsonOptions); //.Deserialize<CustomerData>(jsonDocs[0].RootElement);
