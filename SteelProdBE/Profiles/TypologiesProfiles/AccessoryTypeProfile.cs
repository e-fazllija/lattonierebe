using AutoMapper;
using SteelProdBE.Entities.Typologies;
using SteelProdBE.Models.TypologiesModels.AccessoryTypeModels;

namespace SteelProdBE.Profiles.TypologiesProfiles
{
    public class AccessoryTypeProfile : Profile
    {
        public AccessoryTypeProfile()
        {
            CreateMap<AccessoryType, AccessoryTypeCreateModel>();
            CreateMap<AccessoryType, AccessoryTypeUpdateModel>();
            CreateMap<AccessoryType, AccessoryTypeSelectModel>();

            CreateMap <AccessoryTypeCreateModel, AccessoryType>();
            CreateMap<AccessoryTypeUpdateModel, AccessoryType>();
            CreateMap<AccessoryTypeSelectModel, AccessoryType>();
        }
    }
}
