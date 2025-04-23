using System.Xml.Serialization;

namespace SteelProdBE.Models.Xml.XmlCreateModels
{
    [XmlRoot("job")]

    public class OperaJobPriceCreateModel
    {
        public int JobId { get; set; }
        // PrezzoCommessa
        [XmlElement("job_last_saved_price")]
        public string? job_last_saved_price { get; set; }
    }
}
