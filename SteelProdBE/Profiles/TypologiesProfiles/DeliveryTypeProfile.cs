using AutoMapper;
using SteelProdBE.Entities.Typologies;
using SteelProdBE.Models.TypologiesModels.DeliveryTypeModels;

namespace SteelProdBE.Profiles.TypologiesProfiles
{
    public class DeliveryTypeProfile : Profile
    {
        public DeliveryTypeProfile()
        {
            CreateMap<DeliveryType, DeliveryTypeCreateModel>();
            CreateMap<DeliveryType, DeliveryTypeUpdateModel>();
            CreateMap<DeliveryType, DeliveryTypeSelectModel>();

            CreateMap<DeliveryTypeCreateModel, DeliveryType>();
            CreateMap<DeliveryTypeUpdateModel, DeliveryType>();
            CreateMap<DeliveryTypeSelectModel, DeliveryType>();
        }
    }
}
