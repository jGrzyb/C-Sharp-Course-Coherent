public class Catalog
{
    public Dictionary<Isbn, Book> dictionary = new();


    public void Add(string ISBN, Book book)
    {
        dictionary.Add(new Isbn(ISBN), book);
    }

    public Book? GetBook(string ISBN)
    {
        return dictionary.FirstOrDefault(x => x.Key.ISBN == ISBN).Value;
    }

    public IEnumerable<string> GetTitlesAlphabetical()
    {
        return dictionary.Select(x => x.Value.Title).Order();
    }

    public IEnumerable<Book> GetBooksByAuthor(Author author)
    {
        return dictionary.Select(x => x.Value).Where(x => x.Authors.Contains(author)).OrderBy(x => x.ReleaseDate);
    }

    public IEnumerable<(Author, int)> GetAuthorsWithBookCount()
    {
        return dictionary.Values
            .SelectMany(x => x.Authors)
            .GroupBy(author => author)
            .Select(group => (group.Key, group.Count()));
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, dictionary.Select(x => x.Value.ToString()));
    }

}