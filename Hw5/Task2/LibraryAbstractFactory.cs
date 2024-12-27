using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

public abstract class LibraryAbstractFactory 
{
    private Regex authorRegex = new(@"([\p{L}\p{M}\-\.']+, ?[\p{L}\p{M}\-\.']+(, ?\d{4})?)|([\p{L}\p{M}\-\.']+ [\p{L}\p{M}\-\.']+)");
    private Regex nameRegex = new(@"[\p{L}\p{M}\-\.']+");
    private Regex dateRegex = new(@"\d{4}");

    public Library CreateLibrary(string filePath)
    {
        Catalog catalog = new();
        using(TextFieldParser csvParser = new TextFieldParser(filePath)) 
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

                (string isbn, Book book) = ParseFields(fields);
                if(isbn is null || book is null)
                {
                    continue;
                }
                if(catalog.dictionary.ContainsKey(isbn)) 
                {
                    Console.WriteLine($"Duplicate ISBN: `{isbn}`");
                    continue;
                }
                catalog.dictionary.Add(isbn, book);
                
                //---------------------------------------------
            }
        }
        string[] pressReleaseItems = catalog.dictionary.Values.SelectMany(x => x.GetPressRelease()).Distinct().ToArray();
        return new Library(catalog, pressReleaseItems);
    }


    protected abstract (string, Book) ParseFields(string[] fields);
    protected abstract bool isTypeCorrect(string[] fields);


    protected Author[] ParseAuthors(string authors)
    {
        MatchCollection matches = authorRegex.Matches(authors);
        List<Author> authorList = new();
        if(matches.Count == 0) 
        {
            Console.WriteLine($"Invalid authors: `{authors}`");
        }
        foreach(Match match in matches)
        {
            string firstName = "", lastName = "";
            DateTime? birthDate = null;
            MatchCollection nameMatches = nameRegex.Matches(match.Value);
            MatchCollection dateMatches = dateRegex.Matches(match.Value);

            if(nameMatches.Count == 0) 
            {
                Console.WriteLine($"Invalid author: `{match.Value}`");
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