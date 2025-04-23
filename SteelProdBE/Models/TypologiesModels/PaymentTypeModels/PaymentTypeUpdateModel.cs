namespace SteelProdBE.Models.TypologiesModels.PaymentTypeModels
{
    public class PaymentTypeUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
