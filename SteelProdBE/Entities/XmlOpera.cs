using SteelProdBE.Entities.Xml;
using System.Xml.Serialization;

namespace SteelProdBE.Entities
{
    [Serializable()]
    [XmlRoot("jobs")]
    public class XmlOpera : EntityBase
    {
        [XmlElement("job")]
        public Job Job { get; set; }
        public string? Note { get; set; }
        public string? State { get; set; }
      
    }
}
