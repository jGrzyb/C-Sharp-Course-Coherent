public class ELibraryFactory : LibraryAbstractFactory
{
    protected override (string, Book) ParseFields(string[] fields)
    {
        var (title, releaseDate, authors) = ParseBookFields(fields);

        string[] formats = fields[1].Split(",");
        string downloadUrl = fields[2];

        string identifier = fields[2];


        return (identifier, new EBook(title, new HashSet<Author>(authors), releaseDate, downloadUrl, formats));
    }
    protected override bool isTypeCorrect(string[] fields)
    {
        return fields.Length >= 6 && fields[5] != "";
    }
}