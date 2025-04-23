using SteelProdBE.Entities;
using SteelProdBE.Models.ProfileModels;

namespace SteelProdBE.Profiles
{
    public class ProfileProfile : AutoMapper.Profile
    {
        public ProfileProfile()
        {
            CreateMap<Profile, ProfileCreateModel>();
            CreateMap<Profile, ProfileUpdateModel>();
            CreateMap<Profile, ProfileSelectModel>();
            CreateMap<ProfileSelectModel, ProfileUpdateModel>();
            CreateMap<ProfileUpdateModel, ProfileSelectModel>();

            CreateMap<ProfileCreateModel, Profile>();
            CreateMap<ProfileUpdateModel, Profile>();
            CreateMap<ProfileSelectModel, Profile>();

        }
    }
}
