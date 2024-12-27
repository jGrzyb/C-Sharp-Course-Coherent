public class PaperLibraryFactory : LibraryAbstractFactory
{
    protected override (string, Book) ParseFields(string[] fields)
    {
        var (title, releaseDate, authors) = ParseBookFields(fields);

        string[] isbns = fields[5].Split(",");
        string publisher = fields[4];
        
        string identifier = isbns.Length > 0 && isbns[0].Length > 0 ? isbns[0] : fields[2];


        return (identifier, new PaperBook(title, new HashSet<Author>(authors), releaseDate, publisher, isbns.ToList()));
    }
    protected override bool isTypeCorrect(string[] fields)
    {
        return fields.Length >= 6 && fields[5] == "";
    }
}