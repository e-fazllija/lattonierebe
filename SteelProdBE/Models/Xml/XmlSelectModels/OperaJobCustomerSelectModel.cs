using System.Xml.Serialization;

namespace SteelProdBE.Models.Xml.XmlSelectModels
{
    public class OperaJobCustomerSelectModel
    {
        public int JobId { get; set; }
        // Cliente
        [XmlElement("cst_name")]
        public string? cst_name { get; set; }
        // Codice Cliente
        [XmlElement("cst_code")]
        public string? cst_code { get; set; }
    }
}
