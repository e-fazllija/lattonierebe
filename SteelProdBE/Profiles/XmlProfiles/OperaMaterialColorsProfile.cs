using SteelProdBE.Entities.Xml;
using SteelProdBE.Models.Xml.XmlCreateModels;
using SteelProdBE.Models.Xml.XmlSelectModels;
using SteelProdBE.Models.Xml.XmlUpdateModels;

namespace SteelProdBE.Profiles.XmlProfiles
{
    public class OperaMaterialColorsProfile : AutoMapper.Profile
    {
        public OperaMaterialColorsProfile()
        {
            CreateMap<OperaMaterialColors, OperaMaterialColorsCreateModel>();
            CreateMap<OperaMaterialColors, OperaMaterialColorsUpdateModel>();
            CreateMap<OperaMaterialColors, OperaMaterialColorsSelectModel>();
            CreateMap<OperaMaterialColorsSelectModel, OperaMaterialColorsUpdateModel>();
            CreateMap<OperaMaterialColorsUpdateModel, OperaMaterialColorsSelectModel>();

            CreateMap<OperaMaterialColorsCreateModel, OperaMaterialColors>();
            CreateMap<OperaMaterialColorsUpdateModel, OperaMaterialColors>();
            CreateMap<OperaMaterialColorsSelectModel, OperaMaterialColors>();

            CreateMap<OperaMaterialColor, OperaMaterialColorCreateModel>();
            CreateMap<OperaMaterialColor, OperaMaterialColorUpdateModel>();
            CreateMap<OperaMaterialColor, OperaMaterialColorSelectModel>();
            CreateMap<OperaMaterialColorSelectModel, OperaMaterialColorUpdateModel>();
            CreateMap<OperaMaterialColorUpdateModel, OperaMaterialColorSelectModel>();

            CreateMap<OperaMaterialColorCreateModel, OperaMaterialColor>();
            CreateMap<OperaMaterialColorUpdateModel, OperaMaterialColor>();
            CreateMap<OperaMaterialColorSelectModel, OperaMaterialColor>();
        }
    }
}
