using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

public class Catalog
{
    Dictionary<Isbn, Book> dictionary = new();

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

    public IEnumerable<Book> GetBooksByAuthor(string author)
    {
        return dictionary.Select(x => x.Value).Where(x => x.Authors.Contains(author)).OrderBy(x => x.ReleaseDate);
    }

    public IEnumerable<(string, int)> GetAuthorsWithBookCount()
    {
        return dictionary.Values
            .SelectMany(x => x.Authors)
            .GroupBy(author => author)
            .Select(group => (group.Key, group.Count()));
    }

}