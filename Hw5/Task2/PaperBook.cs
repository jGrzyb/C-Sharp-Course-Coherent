using System.Text.Json.Serialization;
using System.Xml.Serialization;

public class PaperBook : Book {
    [JsonIgnore]
    [XmlIgnore]
    public List<Isbn> Isbns { get; set; } = new();
    [JsonIgnore]
    [XmlIgnore]
    public string Publisher { get; set; } = "";
}