using SteelProdBE.Entities;

namespace SteelProdBE.Models.TypologiesModels.GoodReceiptTypeModels
{
    public class GoodReceiptTypeSelectModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
