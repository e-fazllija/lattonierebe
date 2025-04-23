using System.Xml.Serialization;

namespace SteelProdBE.Models.Xml.XmlUpdateModels
{
    public class OperaMachiningsUpdateModel
    {
        public int OperaCutId { get; set; }
        [XmlElement("machining")]
        public List<OperaMachiningUpdateModel>? OperaMachining { get; set; }

    }
    public class OperaMachiningUpdateModel
    {
        public int OperaMachiningsId { get; set; }
        [XmlElement("mach_name")]
        public string? mach_name { get; set; }
    }
}
