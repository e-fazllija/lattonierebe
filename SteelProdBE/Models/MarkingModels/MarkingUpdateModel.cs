namespace SteelProdBE.Models.MarkingModels
{
    public class MarkingUpdateModel
    {
        public int Id { get; set; }
        public string MaterialName { get; set; }
        public string IdFac { get; set; }
        public string Dx { get; set; }
        public string Dy { get; set; }
        public string Lung { get; set; }
        public string Larg { get; set; }
        public string Str { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
