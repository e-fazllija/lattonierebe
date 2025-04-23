using SteelProdBE.Entities.Xml;
using SteelProdBE.Models.Xml.XmlCreateModels;
using SteelProdBE.Models.Xml.XmlSelectModels;
using SteelProdBE.Models.Xml.XmlUpdateModels;

namespace SteelProdBE.Profiles.XmlProfiles
{
    public class OperaMachiningsProfile : AutoMapper.Profile
    {
        public OperaMachiningsProfile()
        {
            CreateMap<OperaMachinings, OperaMachiningsCreateModel>();
            CreateMap<OperaMachinings, OperaMachiningsUpdateModel>();
            CreateMap<OperaMachinings, OperaMachiningsSelectModel>();
            CreateMap<OperaMachiningsSelectModel, OperaMachiningsUpdateModel>();
            CreateMap<OperaMachiningsUpdateModel, OperaMachiningsSelectModel>();

            CreateMap<OperaMachiningsCreateModel, OperaMachinings>();
            CreateMap<OperaMachiningsUpdateModel, OperaMachinings>();
            CreateMap<OperaMachiningsSelectModel, OperaMachinings>();

            CreateMap<OperaMachining, OperaMachiningCreateModel>();
            CreateMap<OperaMachining, OperaMachiningUpdateModel>();
            CreateMap<OperaMachining, OperaMachiningSelectModel>();
            CreateMap<OperaMachiningSelectModel, OperaMachiningUpdateModel>();
            CreateMap<OperaMachiningUpdateModel, OperaMachiningSelectModel>();

            CreateMap<OperaMachiningCreateModel, OperaMachining>();
            CreateMap<OperaMachiningUpdateModel, OperaMachining>();
            CreateMap<OperaMachiningSelectModel, OperaMachining>();

        }
    }
}
