using System.Xml.Serialization;

namespace SteelProdBE.Entities.Xml
{
    [XmlRoot("job")]
    public class OperaJobPrice : EntityBase
    {
        public int JobId { get; set; }
        // PrezzoCommessa
        [XmlElement("job_last_saved_price")]
        public string? job_last_saved_price { get; set; }
    }
}
