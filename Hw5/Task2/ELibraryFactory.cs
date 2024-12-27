public class ELibraryFactory : LibraryAbstractFactory
{
    protected override (Isbn, Book) ParseFields(string[] fields)
    {
        Author[] authors = ParseAuthors(fields[0]);
        string[] formats = fields[1].Split(",");
        string identifier = fields[2];
        DateTime.TryParse(fields[3], out DateTime releaseDate);
        string downloadUrl = fields[5];
        string title = fields[6];

        return (new Isbn(identifier), new EBook(title, new HashSet<Author>(authors), releaseDate, downloadUrl, formats));
    }
    protected override bool isTypeCorrect(string[] fields)
    {
        return fields.Length >= 6 && fields[5] != "";
    }
}