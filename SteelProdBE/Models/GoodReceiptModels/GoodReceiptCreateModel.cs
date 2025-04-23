using SteelProdBE.Entities;
using SteelProdBE.Models.SupplierModels;

namespace SteelProdBE.Models.GoodReceiptModels
{
    public class GoodReceiptCreateModel
    {
        public int Id { get; set; }
        public int DocumentNumber { get; set; }
        public DateTime Date { get; set; }
        public int TypeId { get; set; }
        public int GoodId { get; set; }
        public string GoodName { get; set; }
        public int Quantity { get; set; }
        public int? SupplierId { get; set; }
        public string? Note { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
