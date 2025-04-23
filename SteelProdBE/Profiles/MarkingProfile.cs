using AutoMapper;
using SteelProdBE.Models.AccessoryModels;
using SteelProdBE.Models.MarkingModels;

namespace SteelProdBE.Profiles
{
    public class MarkingProfile : Profile
    {
        public MarkingProfile()
        {
            CreateMap<SteelProdBE.Entities.Marking, MarkingCreateModel>();
            CreateMap<SteelProdBE.Entities.Marking, MarkingUpdateModel>();
            CreateMap<SteelProdBE.Entities.Marking, MarkingSelectModel>();
            CreateMap<MarkingSelectModel, MarkingUpdateModel>();
            CreateMap<MarkingUpdateModel, MarkingSelectModel>();

            CreateMap<MarkingCreateModel, SteelProdBE.Entities.Marking>();
            CreateMap<MarkingUpdateModel, SteelProdBE.Entities.Marking>();
            CreateMap<MarkingSelectModel, SteelProdBE.Entities.Marking>();

        }
    }
}