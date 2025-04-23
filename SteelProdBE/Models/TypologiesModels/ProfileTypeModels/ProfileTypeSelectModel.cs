namespace SteelProdBE.Models.TypologiesModels.ProfileTypeModels
{
    public class ProfileTypeSelectModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
