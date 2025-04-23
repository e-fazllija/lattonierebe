namespace SteelProdBE.Entities
{
    public class Notification: EntityBase
    {
        public int Code { get; set; }
        public int Identifier { get; set; }
        public string? EntityClassTypologie { get; set; }
        public int EntityClassId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool Seen { get; set; }
        public bool Deleted { get; set; }
    }
}
