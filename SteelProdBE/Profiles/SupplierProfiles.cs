using AutoMapper;
using SteelProdBE.Models.SupplierModels;

namespace SteelProdBE.Profiles
{
    public class SupplierProfiles : Profile
    {
        public SupplierProfiles()
        {
            CreateMap<SteelProdBE.Entities.Supplier, SupplierCreateModel>();
            CreateMap<SteelProdBE.Entities.Supplier, SupplierUpdateModel>();
            CreateMap<SteelProdBE.Entities.Supplier, SupplierSelectModel>();
            CreateMap<SupplierSelectModel, SupplierUpdateModel>();
            CreateMap<SupplierUpdateModel, SupplierSelectModel>();

            CreateMap<SupplierCreateModel, SteelProdBE.Entities.Supplier>();
            CreateMap<SupplierUpdateModel, SteelProdBE.Entities.Supplier>();
            CreateMap<SupplierSelectModel, SteelProdBE.Entities.Supplier>();

        }
    }
}
