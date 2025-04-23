using AutoMapper;
using SteelProdBE.Entities.Typologies;
using SteelProdBE.Models.TypologiesModels.PaymentTypeModels;

namespace SteelProdBE.Profiles.TypologiesProfiles
{
    public class PaymentTypeProfile : Profile
    {
        public PaymentTypeProfile()
        {
            CreateMap<PaymentType, PaymentTypeCreateModel>();
            CreateMap<PaymentType, PaymentTypeUpdateModel>();
            CreateMap<PaymentType, PaymentTypeSelectModel>();

            CreateMap<PaymentTypeCreateModel, PaymentType>();
            CreateMap<PaymentTypeUpdateModel, PaymentType>();
            CreateMap<PaymentTypeSelectModel, PaymentType>();
        }
    }
}
