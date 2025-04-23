using SteelProdBE.Entities.Xml;

namespace SteelProdBE.Models.Xml.XmlUpdateModels
{
    public class XmlOperaUpdateModel
    {
        public int Id { get; set; }
        public JobUpdateModel Job { get; set; }
        public string? Note { get; set; }
        public string? State { get; set; }
    }
}
