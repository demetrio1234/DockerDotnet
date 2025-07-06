using System.Text.Json;

namespace JsonReader.Helpers;

public static class JsonHelper
{
    public static IEnumerable<JsonDocument> GetJsonDocuments(string path)
    {
        IEnumerable<string> files = Directory.EnumerateFileSystemEntries(path);
        List<byte[]> bytes = [.. files.Select(File.ReadAllBytes)];
        return [.. bytes.Select(byteArray => JsonDocument.Parse(byteArray))];
    }
}