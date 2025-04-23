using System.Xml.Serialization;

namespace SteelProdBE.Models.Xml.XmlUpdateModels
{
    public class OperaJobPriceUpdateModel
    {
        public int JobId { get; set; }
        // PrezzoCommessa
        [XmlElement("job_last_saved_price")]
        public string? job_last_saved_price { get; set; }
    }
}
