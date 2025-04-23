using System.Xml.Serialization;

namespace SteelProdBE.Models.Xml.XmlCreateModels
{
    [XmlRoot("job")]
    public class OperaJobCustomerCreateModel
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
