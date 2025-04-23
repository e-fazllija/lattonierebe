using SteelProdBE.Entities;

namespace SteelProdBE.Models.TypologiesModels.GoodReceiptTypeModels
{
    public class GoodReceiptTypeCreateModel
    {
        public string Name { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
    }
}
