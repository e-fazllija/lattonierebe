using SteelProdBE.Entities;
using System.Xml.Serialization;

namespace SteelProdBE.Models.Xml.XmlSelectModels
{
    public class OperaColorsSelectModel
    {
        public int OperaComponentId { get; set; }
        //Qualita
        [XmlElement("color")]
        public List<OperaColorSelectModel>? OperaColor { get; set; }
    }

    public class OperaColorSelectModel
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
