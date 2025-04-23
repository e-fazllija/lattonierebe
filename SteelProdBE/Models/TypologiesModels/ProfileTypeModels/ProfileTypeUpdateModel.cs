namespace SteelProdBE.Models.TypologiesModels.ProfileTypeModels
{
    public class ProfileTypeUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
