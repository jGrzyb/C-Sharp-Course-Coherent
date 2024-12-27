using System.IO;
using System.Text.Json;

public class JsonRepository : IRepository
{
    private const string filePath = "catalog";

    public Catalog? Load()
    {
        if (!Directory.Exists(filePath))
        {
            return default;
        }

        DALCatalogAuthors authorsWithBooks = new();
        foreach (var file in Directory.EnumerateFiles(filePath))
        {
            var json = File.ReadAllText(file);
            var entry = JsonSerializer.Deserialize<DALAuthorEntry>(json);
            if(entry == null)
            {
                Console.WriteLine("-------- Error: Could not deserialize file: " + file);
                entry = new DALAuthorEntry();
            }
            authorsWithBooks.dictionary.Add(entry);
        }

        return authorsWithBooks.ToCatalog();
    }

    public void Save(Catalog catalog)
    {
        if (Directory.Exists(filePath))
        {
            Directory.Delete(filePath, true);
        }

        Directory.CreateDirectory(filePath);

        DALCatalogAuthors authorsWithBooks = new(catalog);
        foreach(var entry in authorsWithBooks.dictionary)
        {
            string fileName = $"{filePath}/{entry.author.Name.Replace(" ", "_")}_{entry.author.Surname.Replace(" ", "_")}.json";
            // string fileName = filePath + "/" + entry.author.Name.Replace(" ", "_") + ".json";
            var json = JsonSerializer.Serialize(entry, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, json);
        }
    }
}