using SteelProdBE.Entities;
using SteelProdBE.Models.MaterialModels;

namespace SteelProdBE.Profiles
{
    public class MaterialProfile : AutoMapper.Profile
    {
        public MaterialProfile()
        {
            CreateMap<Material, MaterialCreateModel>();
            CreateMap<Material, MaterialUpdateModel>();
            CreateMap<Material, MaterialSelectModel>();
            CreateMap<MaterialSelectModel, MaterialUpdateModel>();
            CreateMap<MaterialUpdateModel, MaterialSelectModel>();

            CreateMap<MaterialCreateModel, Material>();
            CreateMap<MaterialUpdateModel, Material>();
            CreateMap<MaterialSelectModel, Material>();

        }
    }
}
