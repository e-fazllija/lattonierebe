namespace SteelProdBE.Entities
{
    public class Invoice : EntityBase
    {
        public string JobId { get; set; }
        public int InvoiceId { get; set; }
        public bool AdvancePayment { get; set; }
        public string Amount { get; set; }
        public int Percentage { get; set; }
    }
}
