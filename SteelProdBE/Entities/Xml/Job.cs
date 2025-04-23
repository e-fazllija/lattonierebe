using System.Xml.Serialization;

namespace SteelProdBE.Entities.Xml
{
    public class Job: EntityBase
    {
        public int XmlOperaId { get; set; }
        // NumeroCommessa
        [XmlElement("job_id")]
        public string? job_id { get; set; }
        // AnnoCommessa
        [XmlElement("job_year")]
        public string? job_year { get; set; }
        // CreatoreCommessa
        [XmlElement("job_creator")]
        public string? job_creator { get; set; }
        // ------
        [XmlElement("job_creation_timestamp")]
        public string? job_creation_timestamp { get; set; }
        // ------
        [XmlElement("job_order_reference")]
        public string? job_order_reference { get; set; }
        // NumeroCommessa
        [XmlElement("job_name")]
        public string? job_name { get; set; }
        // DataInizioCommessa
        [XmlElement("job_status_date")]
        public string? job_status_date { get; set; }
        // Iva
        [XmlElement("job_vat_rate")]
        public string? job_vat_rate { get; set; }
        // Cliente
        [XmlElement("job_customer")]
        public OperaJobCustomer? OperaJobCustomer { get; set; }
        // PrezzoCommessa
        [XmlElement("job_price_details")]
        public OperaJobPrice? OperaJobPrice { get; set; }
        [XmlElement("job_components")]
        public OperaJobComponents? OperaJobComponents { get; set; }
        [XmlElement("materials")]
        public OperaMaterials OperaMaterials { get; set; }
    }

}
