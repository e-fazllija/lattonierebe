namespace SteelProdBE.Models.ProfileXmlModels
{
    public class ProfileXmlCreateModel
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
