[Serializable]
public class DALBookEntry
{
    public string ISBN { get; set; } = "";
    public DALBook Book { get; set; } = new();

    public DALBookEntry()
    {
    }

    public DALBookEntry(Isbn isbn, Book book)
    {
        ISBN = isbn.ISBN;
        Book = new DALBook(book);
    }

    public (Isbn, Book) ToIsbnAndBook()
    {
        return (new Isbn(ISBN), Book.ToBook());
    }
}