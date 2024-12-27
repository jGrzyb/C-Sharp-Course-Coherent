using System.Text.RegularExpressions;

[Serializable]
public class Author 
{
    private string _name = "";
    private string _surname = "";
    private DateTime? _birthDate = null;

    public string Name 
    { 
        get
        {
            return _name;
        }
        set
        {
            _name = setName(value);
        }
    }
    public string Surname
    {
        get
        {
            return _surname;
        }
        set
        {
            _surname = setName(value);
        }
    }
    public DateTime? BirthDate
    {
        get
        {
            return _birthDate;
        }
        set
        {
            _birthDate = value;
        }
    }

    public Author() 
    {
    }

    public Author(string name, string surname, DateTime? birthDate = null) 
    {
        if(name is null) 
        {
            throw new ArgumentNullException(nameof(name));
        }
        if(surname is null) 
        {
            throw new ArgumentNullException(nameof(surname));
        }
        Name = name;
        Surname = surname;
        BirthDate = birthDate;
    }

    public Author(string data)
    {
        string[] words = data.Split(", ");
        if (words.Length == 1)
        {
            Name = words[0];
        }

        if (words.Length == 2)
        {
            Surname = words[1];
        }

        var match = Regex.Match(data, @"\d{4}");
        if (match.Success)
        {
            BirthDate = new DateTime(int.Parse(match.Value), 1, 1);
        }
    }

    public override string ToString() 
    {
        return $"{Name} {Surname}";
    }

    private string setName(string value)
    {
        if(value.Length <= 200)
        {
            return value;
        }
        else
        {
            throw new ArgumentException("Name is too long");
        }
    }
}