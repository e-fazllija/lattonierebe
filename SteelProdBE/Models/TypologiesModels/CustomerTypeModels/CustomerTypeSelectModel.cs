namespace SteelProdBE.Models.TypologiesModels.CustomerTypeModels
{
    public class CustomerTypeSelectModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
