using SteelProdBE.Models.Xml.XmlCreateModels;
using System.Xml.Serialization;

namespace SteelProdBE.Models.Xml.XmlSelectModels
{
    public class JobSelectModel
    {
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
        public OperaJobCustomerSelectModel? OperaJobCustomer { get; set; }
        // PrezzoCommessa
        [XmlElement("job_price_details")]
        public OperaJobPriceSelectModel? OperaJobPrice { get; set; }
        [XmlElement("job_components")]
        public OperaJobComponentsSelectModel? OperaJobComponents { get; set; }
        [XmlElement("materials")]
        public OperaMaterialsSelectModel? OperaMaterials { get; set; }
    }
}
