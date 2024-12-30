using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

public class EBook : Book 
{
    [JsonIgnore]
    [XmlIgnore]
    public string DownloadUrl { get; set; } = "";
    [JsonIgnore]
    [XmlIgnore]
    public string[] Formats { get; set; } = [];
    public int Pages { get; set; } = 0;

    public EBook(string title, HashSet<Author> authors, DateTime time, string downloadUrl, string[] formats) : base(title, authors, time)
    {
        DownloadUrl = downloadUrl;
        Formats = formats;
    }

    public override string[] GetPressRelease()
    {
        return Formats;
    }
}