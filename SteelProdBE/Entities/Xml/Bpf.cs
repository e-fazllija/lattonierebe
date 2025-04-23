namespace SteelProdBE.Entities.Xml
{
    public class Bpf: EntityBase
    {
        public int XmlId { get; set; }
        public int WorkOrderId { get; set; }
        public int JobId { get; set; } = 0;
        public int Quantity { get; set; } = 1;
        public string Error { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool Created { get; set; }
    }
}
