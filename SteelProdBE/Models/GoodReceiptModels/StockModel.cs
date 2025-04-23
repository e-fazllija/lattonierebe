namespace SteelProdBE.Models.GoodReceiptModels
{
    public class StockModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime? LastDeliveryDate { get; set; }
    }
}
