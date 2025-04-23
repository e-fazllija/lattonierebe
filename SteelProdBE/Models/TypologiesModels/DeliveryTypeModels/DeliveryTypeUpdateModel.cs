namespace SteelProdBE.Models.TypologiesModels.DeliveryTypeModels
{
    public class DeliveryTypeUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
