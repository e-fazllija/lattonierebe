using System.Xml.Serialization;

namespace SteelProdBE.Models.Xml.XmlSelectModels
{
    public class OperaMachiningsSelectModel
    {
        public int OperaCutId { get; set; }
        [XmlElement("machining")]
        public List<OperaMachiningSelectModel>? OperaMachining { get; set; }

    }
    public class OperaMachiningSelectModel
    {
        public int OperaMachiningsId { get; set; }
        [XmlElement("mach_name")]
        public string? mach_name { get; set; }
    }
}
