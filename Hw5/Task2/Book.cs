using System.Reflection;

public class Book
{
    public string Title { get; }
    public DateTime? ReleaseDate { get; }
    public HashSet<string> Authors { get; } = new();

    public Book(string title, DateTime? releaseDate = null) 
    {
        Title = title;
        ReleaseDate = releaseDate;
    }
    public Book(string title, string[] authors, DateTime? releaseDate = null) 
    {
        Title = title;
        ReleaseDate = releaseDate;
        Authors = new HashSet<string>(authors);
    }
}