using SteelProdBE.Entities;
using SteelProdBE.Entities.Xml;
using SteelProdBE.Models.Xml.XmlCreateModels;
using SteelProdBE.Models.Xml.XmlSelectModels;
using SteelProdBE.Models.Xml.XmlUpdateModels;

namespace SteelProdBE.Profiles.XmlProfiles
{
    public class XmlOperaProfile : AutoMapper.Profile
    {
        public XmlOperaProfile()
        {
            CreateMap<XmlOpera, XmlOperaCreateModel>();
            CreateMap<XmlOpera, XmlOperaUpdateModel>();
            CreateMap<XmlOpera, XmlOperaSelectModel>();
            CreateMap<XmlOperaSelectModel, XmlOperaUpdateModel>();
            CreateMap<XmlOperaUpdateModel, XmlOperaSelectModel>();

            CreateMap<XmlOperaCreateModel, XmlOpera>();
            CreateMap<XmlOperaUpdateModel, XmlOpera>();
            CreateMap<XmlOperaSelectModel, XmlOpera>();
        }
    }
}
