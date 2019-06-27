using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WeatherForCity.Models.XMLModel
{
    [XmlRoot(ElementName = "weatherdata")]
    public class WeatherData
    {
        [XmlElement(ElementName = "location")]
        public Location Location { get; set; }
        [XmlElement(ElementName = "credit")]
        public string Credit { get; set; }
        [XmlElement(ElementName = "meta")]
        public Meta Meta { get; set; }
        [XmlElement(ElementName = "sun")]
        public Sun Sun { get; set; }
        [XmlElement(ElementName = "forecast")]
        public Forecast Forecast { get; set; }
    }
}
