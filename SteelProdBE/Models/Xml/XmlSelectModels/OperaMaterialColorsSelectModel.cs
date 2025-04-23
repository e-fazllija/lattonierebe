using System.Xml.Serialization;

namespace SteelProdBE.Models.Xml.XmlSelectModels
{
    public class OperaMaterialColorsSelectModel
    {
        public int OperaMaterialId { get; set; }
        //Qualita
        [XmlElement("color")]
        public List<OperaMaterialColorSelectModel>? OperaMaterialColor { get; set; }
    }

    public class OperaMaterialColorSelectModel
    {
        public int OperaMaterialColorsId { get; set; }
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
