namespace SteelProdBE.Models.TypologiesModels.MaterialTypeModels
{
    public class MaterialTypeUpdateModel
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime UpdateDate { get; set; } = DateTime.Now;

    }
}
