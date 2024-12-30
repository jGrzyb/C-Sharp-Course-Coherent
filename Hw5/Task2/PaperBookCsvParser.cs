public class PaperBookCsvParser : AbstractCsvParser
{
    public PaperBookCsvParser(string filePath) : base(filePath)
    {
    }
    
    protected override (string, Book) ParseFields(string[] fields)
    {
        var (title, releaseDate, authors) = ParseBookFields(fields);

        string[] isbns = fields[5].Split(",").Where(x => !string.IsNullOrEmpty(x)).ToArray();
        string? isbn = isbns.FirstOrDefault(x => x.Contains("isbn"))?[9..];
        string publisher = fields[4];
        
        if(isbn == null)
        {
            Logger.Log($"ISBN not found for book: `{title}`");
            return default;
        }


        return (isbn, new PaperBook(title, new HashSet<Author>(authors), releaseDate, publisher, isbns.ToList()));
    }
    protected override bool isTypeCorrect(string[] fields)
    {
        return fields.Length >= 6 && fields[5] == "";
    }
}