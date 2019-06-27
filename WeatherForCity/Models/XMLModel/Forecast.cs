using System.Collections.Generic;
using System.Xml.Serialization;

namespace WeatherForCity.Models.XMLModel
{
    [XmlRoot(ElementName = "forecast")]
    public class Forecast
    {
        [XmlElement(ElementName = "time")]
        public List<Time> Time { get; set; }
    }

}