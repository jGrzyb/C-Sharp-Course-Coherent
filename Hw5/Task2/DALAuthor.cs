[Serializable]
public class DALAuthor
{
    public string Name { get; set; } = "";
    public string Surname { get; set; } = "";
    public DateTime? BirthDate { get; set; } = null;

    public DALAuthor()
    {
    }

    public DALAuthor(Author author)
    {
        Name = author.Name;
        Surname = author.Surname;
        BirthDate = author.BirthDate;
    }

    public Author ToAuthor()
    {
        return new Author(Name, Surname, BirthDate);
    }
}