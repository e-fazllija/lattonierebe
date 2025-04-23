using SteelProdBE.Entities;

namespace SteelProdBE.Models.TypologiesModels.GoodReceiptTypeModels
{
    public class GoodReceiptTypeUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
