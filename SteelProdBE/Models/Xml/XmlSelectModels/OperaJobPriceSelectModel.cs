using System.Xml.Serialization;

namespace SteelProdBE.Models.Xml.XmlSelectModels
{
    public class OperaJobPriceSelectModel
    {
        public int JobId { get; set; }
        // PrezzoCommessa
        [XmlElement("job_last_saved_price")]
        public string? job_last_saved_price { get; set; }
    }
}
