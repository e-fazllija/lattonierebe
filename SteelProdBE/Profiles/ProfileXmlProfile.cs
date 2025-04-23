using SteelProdBE.Entities;
using SteelProdBE.Models.ProfileModels;
using SteelProdBE.Models.ProfileXmlModels;

namespace SteelProdBE.Profiles
{
    public class ProfileXmlProfile : AutoMapper.Profile
    {
        public ProfileXmlProfile()
        {
            CreateMap<ProfileXml, ProfileXmlCreateModel>();
            CreateMap<ProfileXml, ProfileXmlUpdateModel>();
            CreateMap<ProfileXml, ProfileXmlSelectModel>();
            CreateMap<ProfileXmlSelectModel, ProfileXmlUpdateModel>();
            CreateMap<ProfileXmlUpdateModel, ProfileXmlSelectModel>();

            CreateMap<ProfileXmlCreateModel, ProfileXml>();
            CreateMap<ProfileXmlUpdateModel, ProfileXml>();
            CreateMap<ProfileXmlSelectModel, ProfileXml>();

        }
    }
}
