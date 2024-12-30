using System.Text.RegularExpressions;

public class PageGetter
{
    private readonly string url = "https://archive.org/details/";
    private readonly Regex pageRegex = new Regex(@"<span itemprop=""numberOfPages"">\d+</span>");
    private readonly Regex numberRegex = new Regex(@"\d+");

    public async Task<int> GetPages(string downloadUrl)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url + downloadUrl);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    MatchCollection matches = pageRegex.Matches(responseBody);
                    if (matches.Count > 0)
                    {
                        Match match = numberRegex.Match(matches[0].Value);
                        int pages = int.Parse(match.Value);
                        Logger.Log($"GET: {pages,-4} - {downloadUrl}");
                        // Console.Write(".");
                        return pages;
                    }
                }
            }
        }
        catch (Exception e)
        {
            Logger.Log($"Couldn't get pages for {downloadUrl} - {e.Message}");
        }
        return 0;
    }
}