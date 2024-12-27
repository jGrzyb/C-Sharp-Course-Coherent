[Serializable]
public class DALBook {
    public string Title { get; set; } = "";
    public DateTime? ReleaseDate { get; set; }
    public HashSet<Author> Authors { get; set; } = new();

    public DALBook()
    {
    }

    public DALBook(Book book) {
        Title = book.Title;
        ReleaseDate = book.ReleaseDate;
        Authors = new HashSet<Author>(book.Authors);
    }

    public Book ToBook() {
        return new Book(Title, Authors, ReleaseDate);
    }
}