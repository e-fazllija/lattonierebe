using System.Xml.Serialization;

namespace SteelProdBE.Entities.Xml
{
    public class OperaColors : EntityBase
    {
        public int OperaComponentId { get; set; }
        //Qualita
        [XmlElement("color")]
        public List<OperaColor>? OperaColor { get; set; }
    }

    public class OperaColor : EntityBase
    {
        public int OperaColorsId { get; set; }
        [XmlElement("PKEY")]
        public string? PKEY { get; set; }
        [XmlElement("FKEY")]
        public string? FKEY { get; set; }
        [XmlElement("col_type")]
        public string? col_type { get; set; }
        [XmlElement("col_name")]
        public string? col_name { get; set; }
    }
}
