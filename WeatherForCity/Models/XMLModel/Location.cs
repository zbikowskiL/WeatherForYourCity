using System.Xml.Serialization;

namespace WeatherForCity.Models.XMLModel
{
    [XmlRoot(ElementName = "location")]
    public class Location
    {
        [XmlAttribute(AttributeName = "altitude")]
        public string Altitude { get; set; }
        [XmlAttribute(AttributeName = "latitude")]
        public string Latitude { get; set; }
        [XmlAttribute(AttributeName = "longitude")]
        public string Longitude { get; set; }
        [XmlAttribute(AttributeName = "geobase")]
        public string Geobase { get; set; }
        [XmlAttribute(AttributeName = "geobaseid")]
        public string Geobaseid { get; set; }

        [XmlElement(ElementName = "name")]
        public string CityName { get; set; }
    }
}