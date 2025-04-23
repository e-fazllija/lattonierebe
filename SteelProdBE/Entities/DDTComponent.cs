namespace SteelProdBE.Entities
{
    public class TransportComponent : EntityBase
    {
        public int TransportDocumentId { get; set; }
        public virtual TransportDocument TransportDocument { get; set; }
        public string Description { get; set; } = string.Empty;
        public string UM { get; set; } = string.Empty;
        public string Quantity { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
    }
}
