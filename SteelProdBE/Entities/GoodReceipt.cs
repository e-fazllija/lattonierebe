namespace SteelProdBE.Entities
{
    public class GoodReceipt : EntityBase
    {
        public int DocumentNumber { get; set; }
        public DateTime Date { get; set; }
        public int TypeId { get; set; }
        public int GoodId { get; set; }
        public string GoodName { get; set; }
        public int Quantity { get; set; }
        public int? SupplierId { get; set; }
        public virtual Supplier? Supplier { get; set; }
        public string? Note { get; set; }
    }
}
