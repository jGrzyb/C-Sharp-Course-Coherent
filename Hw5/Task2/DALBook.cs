[Serializable]
public class DALBook 
{
    public string Title { get; set; } = "";
    public DateTime? ReleaseDate { get; set; }
    public HashSet<DALAuthor> Authors { get; set; } = new();

    public DALBook()
    {
    }

    public DALBook(Book book) 
    {
        Title = book.Title;
        ReleaseDate = book.ReleaseDate;
        Authors = new HashSet<DALAuthor>(book.Authors.Select(x => new DALAuthor(x)));
    }

    public Book ToBook() 
    {
        return new Book(Title, Authors.Select(x => x.ToAuthor()).ToHashSet(), ReleaseDate);
    }
}