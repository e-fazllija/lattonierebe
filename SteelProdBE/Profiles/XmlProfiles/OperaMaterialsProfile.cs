using SteelProdBE.Entities.Xml;
using SteelProdBE.Models.Xml.XmlCreateModels;
using SteelProdBE.Models.Xml.XmlSelectModels;
using SteelProdBE.Models.Xml.XmlUpdateModels;

namespace SteelProdBE.Profiles.XmlProfiles
{
    public class OperaMaterialsProfile : AutoMapper.Profile
    {
        public OperaMaterialsProfile()
        {
            CreateMap<OperaMaterials, OperaMaterialsCreateModel>();
            CreateMap<OperaMaterials, OperaMaterialsUpdateModel>();
            CreateMap<OperaMaterials, OperaMaterialsSelectModel>();
            CreateMap<OperaMaterialsSelectModel, OperaMaterialsUpdateModel>();
            CreateMap<OperaMaterialsUpdateModel, OperaMaterialsSelectModel>();

            CreateMap<OperaMaterialsCreateModel, OperaMaterials>();
            CreateMap<OperaMaterialsUpdateModel, OperaMaterials>();
            CreateMap<OperaMaterialsSelectModel, OperaMaterials>();

            CreateMap<OperaMaterial, OperaMaterialCreateModel>();
            CreateMap<OperaMaterial, OperaMaterialUpdateModel>();
            CreateMap<OperaMaterial, OperaMaterialSelectModel>();
            CreateMap<OperaMaterialSelectModel, OperaMaterialUpdateModel>();
            CreateMap<OperaMaterialUpdateModel, OperaMaterialSelectModel>();

            CreateMap<OperaMaterialCreateModel, OperaMaterial>();
            CreateMap<OperaMaterialUpdateModel, OperaMaterial>();
            CreateMap<OperaMaterialSelectModel, OperaMaterial>();
        }
    }
}

