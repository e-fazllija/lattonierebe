using SteelProdBE.Entities;
using SteelProdBE.Models.AccessoryModels;

namespace SteelProdBE.Profiles
{
    public class AccessoryProfile : AutoMapper.Profile
    {
        public AccessoryProfile()
        {
            CreateMap<Accessory, AccessoryCreateModel>();
            CreateMap<Accessory, AccessoryUpdateModel>();
            CreateMap<Accessory, AccessorySelectModel>();
            CreateMap<AccessorySelectModel, AccessoryUpdateModel>();
            CreateMap<AccessoryUpdateModel, AccessorySelectModel>();

            CreateMap<AccessoryCreateModel, Accessory>();
            CreateMap<AccessoryUpdateModel, Accessory>();
            CreateMap<AccessorySelectModel, Accessory>();

        }
    }
}
