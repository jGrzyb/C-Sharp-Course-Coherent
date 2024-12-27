public class ELibraryFactory : LibraryAbstractFactory
{
    protected override (Isbn, Book) ParseFields(string[] fields)
    {
        var (title, releaseDate, authors) = ParseBookFields(fields);

        string[] formats = fields[1].Split(",");
        string downloadUrl = fields[5];

        string identifier = fields[2];


        return (new Isbn(identifier), new EBook(title, new HashSet<Author>(authors), releaseDate, downloadUrl, formats));
    }
    protected override bool isTypeCorrect(string[] fields)
    {
        return fields.Length >= 6 && fields[5] != "";
    }
}