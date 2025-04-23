namespace SteelProdBE.Models.MarkingModels
{
    public class MarkingCreateModel
    {
        public string MaterialName { get; set; }
        public string IdFac { get; set; } = "0";
        public string Dx { get; set; } = "0";
        public string Dy { get; set; } = "0";
        public string Lung { get; set; } = "0";
        public string Larg { get; set; } = "0";
        public string Str { get; set; } = "0";
        public string? From { get; set; }
        public string? To { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
