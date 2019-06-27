using System.Xml.Serialization;

namespace WeatherForCity.Models.XMLModel
{
    [XmlRoot(ElementName = "symbol")]
    public class Symbol
    {
        [XmlAttribute(AttributeName = "number")]
        public string Number { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "var")]
        public string Var { get; set; }
    }
}