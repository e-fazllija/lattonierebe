using SteelProdBE.Entities.Xml;
using System.Xml.Serialization;

namespace SteelProdBE.Models.Xml.XmlCreateModels
{
    [Serializable()]
    [XmlRoot("jobs")]
    public class XmlOperaCreateModel
    {
        [XmlElement("job")]
        public JobCreateModel Job { get; set; }
        public string? Note { get; set; }
        public string? State { get; set; }
      
    }
}
