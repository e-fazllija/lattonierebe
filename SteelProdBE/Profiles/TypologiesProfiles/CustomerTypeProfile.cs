using AutoMapper;
using SteelProdBE.Entities.Typologies;
using SteelProdBE.Models.TypologiesModels.CustomerTypeModels;

namespace SteelProdBE.Profiles.TypologiesProfiles
{
    public class CustomerTypeProfile : Profile
    {
        public CustomerTypeProfile()
        {
            CreateMap<CustomerType, CustomerTypeCreateModel>();
            CreateMap<CustomerType, CustomerTypeUpdateModel>();
            CreateMap<CustomerType, CustomerTypeSelectModel>();

            CreateMap<CustomerTypeCreateModel, CustomerType>();
            CreateMap<CustomerTypeUpdateModel, CustomerType>();
            CreateMap<CustomerTypeSelectModel, CustomerType>();
        }
    }
}
