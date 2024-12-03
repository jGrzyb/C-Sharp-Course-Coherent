using Microsoft.VisualBasic.FileIO;

public class Library<T> where T : Catalog, new()
{
    public Catalog catalog;
    public string[] PressReleaseItems => catalog.GetPressReleaseItems();
    
    public Library()
    {
        catalog = new T();
    }

    
    public void readCSV(string path)
    {
        using (TextFieldParser csvParser = new TextFieldParser(path))
        {
            csvParser.CommentTokens = new string[] { "#" };
            csvParser.SetDelimiters(new string[] { "," });
            csvParser.HasFieldsEnclosedInQuotes = true;

            csvParser.ReadLine();

            while (!csvParser.EndOfData)
            {
                string[]? fields = csvParser.ReadFields();
            }
        }
    }
}