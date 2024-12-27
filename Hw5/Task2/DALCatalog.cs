[Serializable]
public class DALCatalog {
    public HashSet<DALBookEntry> dictionary {get; set;} = new();

    public DALCatalog() 
    {
    }

    public DALCatalog(Catalog catalog)
    {
        foreach (var entry in catalog.dictionary)
        {
            dictionary.Add(new DALBookEntry(entry.Key, entry.Value));
        }
    }

    public Catalog ToCatalog()
    {
        Catalog catalog = new();
        foreach (var entry in dictionary)
        {
            var (isbn, book) = entry.ToIsbnAndBook();
            catalog.Add(isbn.ISBN, book);
        }
        return catalog;
    }
}