using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WeatherForCity.Models.XMLModel
{
    [XmlRoot(ElementName = "clouds")]
    public class Clouds
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
        [XmlAttribute(AttributeName = "all")]
        public string All { get; set; }
        [XmlAttribute(AttributeName = "unit")]
        public string Unit { get; set; }
    }
}
