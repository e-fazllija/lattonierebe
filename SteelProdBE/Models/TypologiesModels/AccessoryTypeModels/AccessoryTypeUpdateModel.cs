namespace SteelProdBE.Models.TypologiesModels.AccessoryTypeModels
{
    public class AccessoryTypeUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
