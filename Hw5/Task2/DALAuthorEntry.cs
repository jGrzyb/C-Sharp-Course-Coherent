[Serializable]
public class DALAuthorEntry
{
    public DALAuthor author { get; set; } = new();
    public HashSet<DALBookEntry> BookEntries { get; set; } = new();

    public DALAuthorEntry()
    {
    }

    public DALAuthorEntry(DALAuthor author, HashSet<DALBookEntry> books)
    {
        this.author = author;
        BookEntries = books;
    }
}