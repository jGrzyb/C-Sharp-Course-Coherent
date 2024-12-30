using System.Collections;
using System.Data.Common;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

public abstract class AbstractCsvParser : IEnumerable<(string id, Book book)>
{
    private string _filePath;
    private Regex authorRegex = new(@"([\p{L}\p{M}\-\.']+, ?[\p{L}\p{M}\-\.']+(, ?\d{4})?)|([\p{L}\p{M}\-\.']+ [\p{L}\p{M}\-\.']+)");
    private Regex nameRegex = new(@"[\p{L}\p{M}\-\.']+");
    private Regex dateRegex = new(@"\d{4}");
    private IEnumerator<(string id, Book book)> _enumerator;

    public AbstractCsvParser(string filePath)
    {
        _filePath = filePath;
        _enumerator = GetEnumerator();
    }

    public bool TryGetNextBook(out (string id, Book book) nextBook)
    {
        if (_enumerator.MoveNext())
        {
            nextBook = _enumerator.Current;
            return true;
        }
        nextBook = default;
        return false;
    }


    public IEnumerator<(string id, Book book)> GetEnumerator()
    {
        using(TextFieldParser csvParser = new TextFieldParser(_filePath)) 
        {
            csvParser.CommentTokens = [ "#" ];
            csvParser.SetDelimiters([ "," ]);
            csvParser.HasFieldsEnclosedInQuotes = true;

            csvParser.ReadLine();

            while (!csvParser.EndOfData)
            {
                string[] fields = csvParser.ReadFields() ?? [];
                //---------------------------------------------

                // if(isTypeCorrect(fields)) 
                // {
                //     (string isbn, Book book) = ParseFields(fields);
                //     catalog.dictionary.Add(isbn, book);
                // }

                //---------------------------------------------

                yield return ParseFields(fields);
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


    protected abstract (string, Book) ParseFields(string[] fields);
    protected abstract bool isTypeCorrect(string[] fields);

    

    protected Author[] ParseAuthors(string authors)
    {
        MatchCollection matches = authorRegex.Matches(authors);
        List<Author> authorList = new();
        if(matches.Count == 0) 
        {
            Logger.Log($"Invalid authors: `{authors}`");
        }
        foreach(Match match in matches)
        {
            string firstName = "", lastName = "";
            DateTime? birthDate = null;
            MatchCollection nameMatches = nameRegex.Matches(match.Value);
            MatchCollection dateMatches = dateRegex.Matches(match.Value);

            if(nameMatches.Count == 0) 
            {
                Logger.Log($"Invalid author: `{match.Value}`");
                continue;
            }

            if(nameMatches.Count >= 1) 
            {
                lastName = nameMatches[0].Value;
            }
            if(nameMatches.Count >= 2) 
            {
                firstName = nameMatches[1].Value;
            }

            if(dateMatches.Count >= 1) 
            {
                birthDate = new DateTime(int.Parse(dateMatches[0].Value), 1, 1);
            }
            
            Author author;
            if(birthDate is null) 
            {
                author = new Author(firstName, lastName);
            } else 
            {
                author = new Author(firstName, lastName, birthDate.Value);
            }
            authorList.Add(author);
        }
        return authorList.ToArray();
    }

    protected (string, DateTime, Author[]) ParseBookFields(string[] fields)
    {
        string title = fields[6];
        DateTime.TryParse(fields[3], out DateTime releaseDate);
        Author[] authors = ParseAuthors(fields[0]);
        return (title, releaseDate, authors);
    }
}