[Serializable]
public class DALCatalogAuthors
{
    public HashSet<DALAuthorEntry> dictionary { get; set; } = new();

    public DALCatalogAuthors()
    {
    }

    public DALCatalogAuthors(Catalog catalog)
    {
        IEnumerable<Author> authors = catalog.dictionary.Values.SelectMany(x => x.Authors).Distinct();
        Dictionary<Author, HashSet<DALBookEntry>> authorsWithBooks = new();

        foreach (var entry in catalog.dictionary)
        {
            foreach (var author in entry.Value.Authors)
            {
                if(!authorsWithBooks.ContainsKey(author))
                {
                    authorsWithBooks.Add(author, new HashSet<DALBookEntry>());
                }
                authorsWithBooks[author].Add(new DALBookEntry(entry.Key, entry.Value));
            }
        }
        dictionary = authorsWithBooks.Select(x => new DALAuthorEntry(x.Key, x.Value)).ToHashSet();
    }

    public Catalog ToCatalog()
    {
        Catalog catalog = new();
        IEnumerable<DALBookEntry> distinctEntries = dictionary.SelectMany(x => x.BookEntries).DistinctBy(x => x.ISBN);
        foreach (var entry in distinctEntries)
        {
            var (isbn, book) = entry.ToIsbnAndBook();
            catalog.Add(isbn.ISBN, book);
        }
        return catalog;
    }
}