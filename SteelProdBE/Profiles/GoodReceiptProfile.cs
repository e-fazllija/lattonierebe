using AutoMapper;
using SteelProdBE.Entities;
using SteelProdBE.Models.GoodReceiptModels;

namespace SteelProdBE.Profiles
{
    public class GoodReceiptProfile : AutoMapper.Profile
    {
        public GoodReceiptProfile()
        {
            CreateMap<GoodReceipt, GoodReceiptCreateModel>();
            CreateMap<GoodReceipt, GoodReceiptUpdateModel>();
            CreateMap<GoodReceipt, GoodReceiptSelectModel>();
            CreateMap<GoodReceiptSelectModel, GoodReceiptUpdateModel>();
            CreateMap<GoodReceiptUpdateModel, GoodReceiptSelectModel>();

            CreateMap<GoodReceiptCreateModel, GoodReceipt>();
            CreateMap<GoodReceiptUpdateModel, GoodReceipt>();
            CreateMap<GoodReceiptSelectModel, GoodReceipt>();

        }
    }
}
