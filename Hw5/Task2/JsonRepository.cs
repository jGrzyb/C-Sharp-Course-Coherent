using System.IO;
using System.Text.Json;

public class JsonRepository : IRepository
{
    public Catalog? Load(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return default;
        }

        var json = File.ReadAllText(filePath);
        var strDict = JsonSerializer.Deserialize<Dictionary<string, Book>>(json, new JsonSerializerOptions { IncludeFields = true });
        
        if (strDict == null)
        {
            return default;
        }

        Catalog catalog = new();
        foreach (var (key, value) in strDict)
        {
            catalog.Add(key, value);
        }

        return catalog;
    }

    public void Save(string filePath, Catalog catalog)
    {
        var strDict = catalog.dictionary.ToDictionary(x => x.Key, x => x.Value);
        var json = JsonSerializer.Serialize(strDict, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
}