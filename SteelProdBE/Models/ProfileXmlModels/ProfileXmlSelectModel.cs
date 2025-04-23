namespace SteelProdBE.Models.ProfileXmlModels
{
    public class ProfileXmlSelectModel
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
