public class Catalog
{
    public Dictionary<string, Book> dictionary = new();


    public Catalog()
    {
    }

    public virtual void Add(string source, Book book)
    {
        if (!isKeyCorrect(source))
        {
            throw new ArgumentException("The key is not correct.");
        }
        dictionary.Add(source, book);
    }

    public Book? GetBook(string source)
    {
        return dictionary.FirstOrDefault(x => x.Key == source).Value;
    }

    public IEnumerable<string> GetTitlesAlphabetical()
    {
        return dictionary.Select(x => x.Value.Title).Order();
    }

    public IEnumerable<Book> GetBooksByAuthor(string author)
    {
        return dictionary.Select(x => x.Value).Where(x => x.Authors.Select(n => n.ToString()).Contains(author)).OrderBy(x => x.ReleaseDate);
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

    public virtual string[] GetPressReleaseItems() => [];

    protected virtual bool isKeyCorrect(string key) => true;
}