using System.Xml.Serialization;

namespace WeatherForCity.Models.XMLModel
{
    [XmlRoot(ElementName = "sun")]
    public class Sun
    {
        [XmlAttribute(AttributeName = "rise")]
        public string Rise { get; set; }
        [XmlAttribute(AttributeName = "set")]
        public string Set { get; set; }
    }
}