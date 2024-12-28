using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

public class EBook : Book 
{
    private Regex pageRegex = new Regex(@"<span itemprop=""numberOfPages"">\d+</span>");
    private Regex numberRegex = new Regex(@"\d+");
    private string url = "https://archive.org/details/";

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

    public async Task GetPages()
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url + DownloadUrl);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    MatchCollection matches = pageRegex.Matches(responseBody);
                    if (matches.Count > 0)
                    {
                        Match match = numberRegex.Match(matches[0].Value);
                        Pages = int.Parse(match.Value);
                        Console.WriteLine($"GET: {Pages.ToString().PadRight(4)} - {Title}");
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public override string[] GetPressRelease()
    {
        return Formats;
    }
}