[Serializable]
public class DALAuthorEntry
{
    public Author author { get; set; } = new();
    public HashSet<DALBookEntry> BookEntries { get; set; } = new();

    public DALAuthorEntry()
    {
    }

    public DALAuthorEntry(Author author, HashSet<DALBookEntry> books)
    {
        this.author = author;
        BookEntries = books;
    }
}