using SteelProdBE.Entities;
using SteelProdBE.Models.AccessoryModels;
using SteelProdBE.Models.MaterialModels;
using SteelProdBE.Models.ProfileModels;
using SteelProdBE.Models.SupplierModels;

namespace SteelProdBE.Models.GoodReceiptModels
{
    public class GoodReceiptSelectModel
    {
        public int Id { get; set; }
        public int DocumentNumber { get; set; }
        public DateTime Date { get; set; }
        public int TypeId { get; set; }
        public int GoodId { get; set; }
        public string GoodName { get; set; }
        public virtual GoodModel Material { get; set; } = new GoodModel();
        public int Quantity { get; set; }
        public int? SupplierId { get; set; }
        public virtual SupplierSelectModel? Supplier { get; set; }
        public string? Note { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
