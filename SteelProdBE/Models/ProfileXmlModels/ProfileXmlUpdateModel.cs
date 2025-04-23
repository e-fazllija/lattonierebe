namespace SteelProdBE.Models.ProfileXmlModels
{
    public class ProfileXmlUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
