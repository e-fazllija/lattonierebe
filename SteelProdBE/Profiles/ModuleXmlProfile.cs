using SteelProdBE.Entities;
using SteelProdBE.Models.MaterialModels;
using SteelProdBE.Models.ModuleXmlModels;



namespace SteelProdBE.Profiles
{
    public class ModuleXmlProfile : AutoMapper.Profile
    {
        public ModuleXmlProfile()
        {
            CreateMap<ModuleXml, ModuleXmlCreateModel>();
            CreateMap<ModuleXml, ModuleXmlUpdateModel>();
            CreateMap<ModuleXml, ModuleXmlSelectModel>();
            CreateMap<ModuleXmlSelectModel, ModuleXmlUpdateModel>();
            CreateMap<ModuleXmlUpdateModel, ModuleXmlSelectModel>();

            CreateMap<ModuleXmlCreateModel, ModuleXml>();
            CreateMap<ModuleXmlUpdateModel, ModuleXml>();
            CreateMap<ModuleXmlSelectModel, ModuleXml>();
        }
    }
}
