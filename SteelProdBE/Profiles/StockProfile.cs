using SteelProdBE.Entities;
using SteelProdBE.Models.AccessoryModels;
using SteelProdBE.Models.GoodReceiptModels;

namespace SteelProdBE.Profiles
{
    public class StockProfile : AutoMapper.Profile
    {
        public StockProfile()
        {
            CreateMap<Accessory, GoodModel>();
            CreateMap<Material, GoodModel>();
            CreateMap<Profile, GoodModel>();

            CreateMap<GoodModel, Accessory>();
            CreateMap<GoodModel, Material>();
            CreateMap<GoodModel, Profile>();

        }
    }
}
