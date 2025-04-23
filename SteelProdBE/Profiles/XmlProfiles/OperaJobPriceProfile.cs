using SteelProdBE.Entities.Xml;
using SteelProdBE.Models.Xml.XmlCreateModels;
using SteelProdBE.Models.Xml.XmlSelectModels;
using SteelProdBE.Models.Xml.XmlUpdateModels;

namespace SteelProdBE.Profiles.XmlProfiles
{
    public class OperaJobPriceProfile : AutoMapper.Profile
    {
        public OperaJobPriceProfile()
        {
            CreateMap<OperaJobPrice, OperaJobPriceCreateModel>();
            CreateMap<OperaJobPrice, OperaJobPriceUpdateModel>();
            CreateMap<OperaJobPrice, OperaJobPriceSelectModel>();
            CreateMap<OperaJobPriceSelectModel, OperaJobPriceUpdateModel>();
            CreateMap<OperaJobPriceUpdateModel, OperaJobPriceSelectModel>();

            CreateMap<OperaJobPriceCreateModel, OperaJobPrice>();
            CreateMap<OperaJobPriceUpdateModel, OperaJobPrice>();
            CreateMap<OperaJobPriceSelectModel, OperaJobPrice>();

        }
    }
}
