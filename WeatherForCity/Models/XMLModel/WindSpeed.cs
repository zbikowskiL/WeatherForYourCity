using System.Xml.Serialization;

namespace WeatherForCity.Models.XMLModel
{
    [XmlRoot(ElementName = "windSpeed")]
    public class WindSpeed
    {
        [XmlAttribute(AttributeName = "mps")]
        public string Mps { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
    }
}