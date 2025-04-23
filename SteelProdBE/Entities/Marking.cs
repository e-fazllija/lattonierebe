namespace SteelProdBE.Entities
{
    public class Marking: EntityBase
    {
        public string MaterialName { get; set; }
        public string IdFac { get; set; }
        public string Dx { get; set; }
        public string Dy { get; set; }
        public string Lung { get; set; }
        public string Larg { get; set; }
        public string Str { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
    }
}
