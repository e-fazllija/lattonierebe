using AutoMapper;
using SteelProdBE.Entities.Typologies;
using SteelProdBE.Models.TypologiesModels.ProfileTypeModels;

namespace SteelProdBE.Profiles.TypologiesProfiles
{
    public class ProfileTypeProfile : Profile
    {
        public ProfileTypeProfile()
        {
            CreateMap<ProfileType, ProfileTypeCreateModel>();
            CreateMap<ProfileType, ProfileTypeUpdateModel>();
            CreateMap<ProfileType, ProfileTypeSelectModel>();

            CreateMap<ProfileTypeCreateModel, ProfileType>();
            CreateMap<ProfileTypeUpdateModel, ProfileType>();
            CreateMap<ProfileTypeSelectModel, ProfileType>();
        }
    }
}
