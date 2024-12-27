using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

public class Catalog
{
    public Dictionary<Isbn, Book> dictionary = new();


    public Catalog()
    {
    }

    public void Add(string ISBN, Book book)
    {
        dictionary.Add(new Isbn(ISBN), book);
    }

    public Book? GetBook(string source)
    {
        return dictionary.FirstOrDefault(x => x.Key.ISBN == source).Value;
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

    public virtual string[] GetPressReleaseItems() => [];

    public virtual void ReadCSV(string path)
    {
        foreach (var line in ReadCsvLines(path))
        {
            Add(
                line[3], 
                new Book(
                    line[6], 
                    new HashSet<Author>([new Author(line[0], "")]), 
                    DateTime.Parse(line[0])
                )
            );
        }
    }

    protected virtual bool isKeyCorrect(string key) => true;

    protected IEnumerable<string[]> ReadCsvLines(string path)
    {
        using (TextFieldParser csvParser = new TextFieldParser(path))
        {
            csvParser.CommentTokens = new string[] { "#" };
            csvParser.SetDelimiters(new string[] { "," });
            csvParser.HasFieldsEnclosedInQuotes = true;

            csvParser.ReadLine();

            while (!csvParser.EndOfData)
            {
                yield return csvParser.ReadFields() ?? [];
            }
        }
    }
}