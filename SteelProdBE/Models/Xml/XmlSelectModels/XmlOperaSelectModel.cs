using SteelProdBE.Entities.Xml;
using System.Xml.Serialization;

namespace SteelProdBE.Models.Xml.XmlSelectModels
{
    public class XmlOperaSelectModel
    {
        public int Id { get; set; }
        public JobSelectModel Job { get; set; }
        public string? Note { get; set; }
        public string? State { get; set; }
    }
}
