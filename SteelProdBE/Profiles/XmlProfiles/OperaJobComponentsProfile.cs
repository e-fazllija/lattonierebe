using SteelProdBE.Entities.Xml;
using SteelProdBE.Models.Xml.XmlCreateModels;
using SteelProdBE.Models.Xml.XmlSelectModels;
using SteelProdBE.Models.Xml.XmlUpdateModels;

namespace SteelProdBE.Profiles.XmlProfiles
{
    public class OperaJobComponentsProfile : AutoMapper.Profile
    {
        public OperaJobComponentsProfile()
        {
            CreateMap<OperaJobComponents, OperaJobComponentsCreateModel>();
            CreateMap<OperaJobComponents, OperaJobComponentsUpdateModel>();
            CreateMap<OperaJobComponents, OperaJobComponentsSelectModel>();
            CreateMap<OperaJobComponentsSelectModel, OperaJobComponentsUpdateModel>();
            CreateMap<OperaJobComponentsUpdateModel, OperaJobComponentsSelectModel>();

            CreateMap<OperaJobComponentsCreateModel, OperaJobComponents>();
            CreateMap<OperaJobComponentsUpdateModel, OperaJobComponents>();
            CreateMap<OperaJobComponentsSelectModel, OperaJobComponents>();

            CreateMap<OperaComponent, OperaComponentCreateModel>();
            CreateMap<OperaComponent, OperaComponentUpdateModel>();
            CreateMap<OperaComponent, OperaComponentSelectModel>();
            CreateMap<OperaComponentSelectModel, OperaComponentUpdateModel>();
            CreateMap<OperaComponentUpdateModel, OperaComponentSelectModel>();

            CreateMap<OperaComponentCreateModel, OperaComponent>();
            CreateMap<OperaComponentUpdateModel, OperaComponent>();
            CreateMap<OperaComponentSelectModel, OperaComponent>();
        }
    }
}
