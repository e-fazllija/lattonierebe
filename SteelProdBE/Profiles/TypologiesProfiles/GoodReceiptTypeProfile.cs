using AutoMapper;
using SteelProdBE.Entities.Typologies;
using SteelProdBE.Models.TypologiesModels.GoodReceiptTypeModels;

namespace SteelProdBE.Profiles.TypologiesProfiles
{
    public class GoodReceiptTypeProfile : Profile
    {
        public GoodReceiptTypeProfile()
        {
            CreateMap<GoodReceiptType, GoodReceiptTypeCreateModel>();
            CreateMap<GoodReceiptType, GoodReceiptTypeUpdateModel>();
            CreateMap<GoodReceiptType, GoodReceiptTypeSelectModel>();

            CreateMap<GoodReceiptTypeCreateModel, GoodReceiptType>();
            CreateMap<GoodReceiptTypeUpdateModel, GoodReceiptType>();
            CreateMap<GoodReceiptTypeSelectModel, GoodReceiptType>();
        }
    }
}
