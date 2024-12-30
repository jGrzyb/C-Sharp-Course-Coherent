using System.Text.RegularExpressions;

public class Author 
{
    const int max_length = 200;
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
            CheckName(value);
            _name = value;
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
            CheckName(value);
            _surname = value;
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

    public override string ToString() 
    {
        return $"{Name} {Surname}";
    }

    private void CheckName(string value)
    {
        if(value.Length > max_length)
        {
            throw new ArgumentException("Name is too long");
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is Author other)
        {
            return Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Name.ToLowerInvariant().GetHashCode();
    }
}