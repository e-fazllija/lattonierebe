namespace SteelProdBE.Entities
{
    public class TransportDocument: EntityBase
    {
        public int XmlId { get; set; }
        public int ClientId { get; set; }
        public int DocumentNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Packages { get; set; }
        public string? Note { get; set; }
        public string? Weight { get; set; }
        public string? Vector { get; set; }
        public string? Vehicle { get; set; }
        public string? Aspect { get; set; }
        public string? ReasonForTransportation { get; set; }
        public bool VisiblePrice { get; set; }
        public DateTime WithdrawalDate { get; set; }
        public string? COP1 { get; set; }
        public string? COP2 { get; set; }
        public string? SpettabileName { get; set; }
        public string? SpettabileAddress1 { get; set; }
        public string? SpettabileAddress2 { get; set; }
        public string? SpettabileVatNumber { get; set; }
        public string? SpettabileFiscalCode { get; set; }
    }
}
