using SteelProdBE.Entities.Typologies;
using SteelProdBE.Models.OutputModels;
using SteelProdBE.Models.TypologiesModels.ProfileTypeModels;

namespace SteelProdBE.Interfaces.IBusinessServices.ITypologiesServices
{
    public interface IProfileTypeServices
    {
        Task<ProfileTypeSelectModel> Create(ProfileTypeCreateModel dto);
        Task<ListViewModel<ProfileTypeSelectModel>> Get(int currentPage, string? filterRequest);
        Task<ProfileTypeSelectModel> Update(ProfileTypeUpdateModel dto);
        Task<ProfileTypeSelectModel> GetById(int id);
        Task<ProfileType> Delete(int id);
    }
}
