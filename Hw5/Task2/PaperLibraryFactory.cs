public class PaperLibraryFactory : ILibraryFactory
{
    Catalog? catalog;

    public Catalog CreateCatalog(string filePath)
    {
        catalog = new();
        PaperBookCsvParser csvParser = new(filePath);
        while (csvParser.TryGetNextBook(out var entry))
        {
            if (entry.id is not null && entry.book is not null && !catalog.dictionary.ContainsKey(entry.id))
            {
                catalog.Add(entry.id, entry.book);
            }
        }
        return catalog;
    }

    public string[] CreatePressReleaseItems()
    {
        if (catalog is null)
        {
            throw new InvalidOperationException("Catalog is not created");
        }
        return catalog.dictionary.Values.SelectMany(x => x.GetPressRelease()).Distinct().ToArray();
    }
}