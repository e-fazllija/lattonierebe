using SteelProdBE.Entities;
using SteelProdBE.Entities.Xml;
using System.Xml.Serialization;

namespace SteelProdBE.Models.Xml.XmlCreateModels
{
    public class OperaMachiningsCreateModel
    {
        public int OperaCutId { get; set; }
        [XmlElement("machining")]
        public List<OperaMachiningCreateModel>? OperaMachining { get; set; }

    }
    public class OperaMachiningCreateModel
    {
        public int OperaMachiningsId { get; set; }
        [XmlElement("mach_name")]
        public string? mach_name { get; set; }
    }
}
