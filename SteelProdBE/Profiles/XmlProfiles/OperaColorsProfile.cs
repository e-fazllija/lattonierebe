using SteelProdBE.Entities.Xml;
using SteelProdBE.Models.Xml.XmlCreateModels;
using SteelProdBE.Models.Xml.XmlSelectModels;
using SteelProdBE.Models.Xml.XmlUpdateModels;

namespace SteelProdBE.Profiles.XmlProfiles
{
    public class OperaColorsProfile : AutoMapper.Profile
    {
        public OperaColorsProfile()
        {
            CreateMap<OperaColors, OperaColorsCreateModel>();
            CreateMap<OperaColors, OperaColorsUpdateModel>();
            CreateMap<OperaColors, OperaColorsSelectModel>();
            CreateMap<OperaColorsSelectModel, OperaColorsUpdateModel>();
            CreateMap<OperaColorsUpdateModel, OperaColorsSelectModel>();

            CreateMap<OperaColorsCreateModel, OperaColors>();
            CreateMap<OperaColorsUpdateModel, OperaColors>();
            CreateMap<OperaColorsSelectModel, OperaColors>();

            CreateMap<OperaColor, OperaColorCreateModel>();
            CreateMap<OperaColor, OperaColorUpdateModel>();
            CreateMap<OperaColor, OperaColorSelectModel>();
            CreateMap<OperaColorSelectModel, OperaColorUpdateModel>();
            CreateMap<OperaColorUpdateModel, OperaColorSelectModel>();

            CreateMap<OperaColorCreateModel, OperaColor>();
            CreateMap<OperaColorUpdateModel, OperaColor>();
            CreateMap<OperaColorSelectModel, OperaColor>();
        }
    }
}
