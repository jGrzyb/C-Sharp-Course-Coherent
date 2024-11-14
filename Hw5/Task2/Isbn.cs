using System.Text.RegularExpressions;

public class Isbn 
{
    public string ISBN { get; }

    private readonly Regex r0 = new(@"\d{3}-\d{1}-\d{2}-\d{6}-\d{1}");
    private readonly Regex r1 = new Regex(@"\d{13}");

    public Isbn(string ISBN) 
    {
        if(!r0.Match(ISBN).Success && !r1.Match(ISBN).Success) 
        {
            throw new ArgumentException("Bad format of ISBN. It should be: XXX-X-XX-XXXXXX-X or XXXXXXXXXXXXX where X is digit");
        }
        this.ISBN = ISBN;
    }
}