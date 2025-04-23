using SteelProdBE.Models.AccessoryModels;

namespace SteelProdBE.ViewModels.AccessoryViewModel
{
    public class AccessoryListViewModel
    {
        public List<AccessorySelectModel> AccessoryTypeSelectModel = new List<AccessorySelectModel>();
        public decimal Total { get; set; }
    }
}
