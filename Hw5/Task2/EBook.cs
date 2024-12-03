using System.Text.Json.Serialization;
using System.Xml.Serialization;

public class EBook : Book {
    [JsonIgnore]
    [XmlIgnore]
    public string DownloadUrl { get; set; } = "";
    [JsonIgnore]
    [XmlIgnore]
    public string[] Formats { get; set; } = [];
}