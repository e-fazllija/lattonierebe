using SteelProdBE.Entities.Xml;
using SteelProdBE.Models.Xml.XmlCreateModels;
using SteelProdBE.Models.Xml.XmlSelectModels;
using SteelProdBE.Models.Xml.XmlUpdateModels;

namespace SteelProdBE.Profiles.XmlProfiles
{
    public class OperaCutsProfile : AutoMapper.Profile
    {
        public OperaCutsProfile()
        {
            CreateMap<OperaCuts, OperaCutsCreateModel>();
            CreateMap<OperaCuts, OperaCutsUpdateModel>();
            CreateMap<OperaCuts, OperaCutsSelectModel>();
            CreateMap<OperaCutsSelectModel, OperaCutsUpdateModel>();
            CreateMap<OperaCutsUpdateModel, OperaCutsSelectModel>();

            CreateMap<OperaCutsCreateModel, OperaCuts>();
            CreateMap<OperaCutsUpdateModel, OperaCuts>();
            CreateMap<OperaCutsSelectModel, OperaCuts>();

            CreateMap<OperaCut, OperaCutCreateModel>();
            CreateMap<OperaCut, OperaCutUpdateModel>();
            CreateMap<OperaCut, OperaCutSelectModel>();
            CreateMap<OperaCutSelectModel, OperaCutUpdateModel>();
            CreateMap<OperaCutUpdateModel, OperaCutSelectModel>();

            CreateMap<OperaCutCreateModel, OperaCut>();
            CreateMap<OperaCutUpdateModel, OperaCut>();
            CreateMap<OperaCutSelectModel, OperaCut>();
        }
    }
    
    
}
