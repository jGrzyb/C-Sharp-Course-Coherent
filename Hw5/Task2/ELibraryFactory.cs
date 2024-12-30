public class ELibraryFactory : ILibraryFactory
{
    Catalog? catalog;

    public Catalog CreateCatalog(string filePath)
    {
        catalog = new();
        EBookCsvParser csvParser = new(filePath);
        foreach (var entry in csvParser)
        {
            if(entry.id is not null && entry.book is not null && !catalog.dictionary.ContainsKey(entry.id))
            {
                catalog.Add(entry.id, entry.book);
            }
            
        }
        PageGetter pageGetter = new();
        Task.WaitAll(catalog.dictionary.Values.ToList().Cast<EBook>().Select(async x => {
            x.Pages = await pageGetter.GetPages(x.DownloadUrl);
        }).ToArray());
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