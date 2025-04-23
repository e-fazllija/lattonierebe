using AutoMapper;
using SteelProdBE.Entities.Typologies;
using SteelProdBE.Models.TypologiesModels.MaterialTypeModels;

namespace SteelProdBE.Profiles.TypologiesProfiles
{
    public class MaterialTypeProfile : Profile
    {
        public MaterialTypeProfile()
        {
            CreateMap<MaterialType, MaterialTypeCreateModel>();
            CreateMap<MaterialType, MaterialTypeUpdateModel>();
            CreateMap<MaterialType, MaterialTypeSelectModel>();

            CreateMap<MaterialTypeCreateModel, MaterialType>();
            CreateMap<MaterialTypeUpdateModel, MaterialType>();
            CreateMap<MaterialTypeSelectModel, MaterialType>();
        }
    }
}
