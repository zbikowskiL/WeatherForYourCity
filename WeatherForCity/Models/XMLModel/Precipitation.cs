using System.Xml.Serialization;

namespace WeatherForCity.Models.XMLModel
{
    [XmlRoot(ElementName = "precipitation")]
    public class Precipitation
    {
        [XmlAttribute(AttributeName = "unit")]
        public string Unit { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
    }
}