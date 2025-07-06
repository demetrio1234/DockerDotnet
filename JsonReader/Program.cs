using JsonReader.Converters;
using Model.Models;
using JsonReader.Constants;
using System.Text.Json;
using JsonReader.Helpers;

JsonSerializerOptions jsonOptions = new(JsonSerializerDefaults.Web)
{
    PropertyNameCaseInsensitive = true,
    DictionaryKeyPolicy = JsonNamingPolicy.CamelCase
};

jsonOptions.Converters.Add(new DateTimeOffsetConverterUsingDateTimeParse());

string path = DirectoryHelper.RecurseTillFound(Directory.GetCurrentDirectory(), AppConfig.DummyJsonData, true);
var jsonDocs = JsonHelper.GetJsonDocuments(path);

var customerData = JsonSerializer.Deserialize<CustomerData>(jsonDocs.ElementAt(1), jsonOptions);

if (customerData is not null)
{
    Console.WriteLine(customerData.User.Email);
    Console.WriteLine(customerData.User.Name);
    Console.WriteLine(customerData.User.Orders.ElementAt(0).Id);
}