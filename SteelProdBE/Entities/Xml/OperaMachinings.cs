using System.Xml.Serialization;

namespace SteelProdBE.Entities.Xml
{
    public class OperaMachinings : EntityBase
    {
        public int OperaCutId { get; set; }
        [XmlElement("machining")]
        public List<OperaMachining>? OperaMachining { get; set; }
    }

    public class OperaMachining : EntityBase
    {
        public int OperaMachiningsId { get; set; }
        [XmlElement("mach_name")]
        public string? mach_name { get; set; }
    }
}
