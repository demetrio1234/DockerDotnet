using JsonReader.Converters;
using Model.Models;
using JsonReader.Constants;
using System.Text.Json;
using JsonReader.Helpers;

JsonSerializerOptions jsonOptions = new(JsonSerializerDefaults.Web);
jsonOptions.Converters.Add(new DateTimeOffsetConverterUsingDateTimeParse());

string folderName = AppConfig.DummyJsonData;

string path = DirectoryHelper.RecurseTillFound(Directory.GetCurrentDirectory(), folderName, true);
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