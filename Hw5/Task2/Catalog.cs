using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

public class Catalog
{
    Dictionary<string, Book> dictionary = new();
    private Regex r0 = new Regex(@"\d{3}-\d{1}-\d{2}-\d{6}-\d{1}");
    private Regex r1 = new Regex(@"\d{13}");

    public void Add(string ISBN, Book book)
    {
        if(r0.Match(ISBN).Success || r1.Match(ISBN).Success) 
        {
            dictionary.Add(ISBN.Replace("-", ""), book);
        }
        else 
        {
            throw new ArgumentException("Bad format of ISBN. It should be: XXX-X-XX-XXXXXX-X or XXXXXXXXXXXXX where X is digit");
        }
    }

    public Book? GetBook(string ISBN)
    {
        if(r0.Match(ISBN).Success || r1.Match(ISBN).Success) 
        {
            dictionary.TryGetValue(ISBN.Replace("-", ""), out Book? book);
            return book ?? null;
        }
        else
        {
            throw new ArgumentException("Bad format of ISBN. It should be: XXX-X-XX-XXXXXX-X or XXXXXXXXXXXXX where X is digit");
        }
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
            .Distinct()
            .Select(x => (x, dictionary.Values.Count(y => y.Authors.Contains(x))));
    }

}