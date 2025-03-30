var currentDirectory = Directory.GetCurrentDirectory();
var folderName = "DummyJsonData";
var path = Path.Combine([currentDirectory, folderName]);
var files = Directory.EnumerateFileSystemEntries(path);

Console.WriteLine("Here a list of all json files:");
foreach (var file in files)
    Console.WriteLine(file);

// var storeJson = await File.ReadAllBytesAsync(File.Exists())