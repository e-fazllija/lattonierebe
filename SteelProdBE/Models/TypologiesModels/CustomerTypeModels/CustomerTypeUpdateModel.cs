namespace SteelProdBE.Models.TypologiesModels.CustomerTypeModels
{
    public class CustomerTypeUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
