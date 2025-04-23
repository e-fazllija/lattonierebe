using SteelProdBE.Entities;
using SteelProdBE.Models.ProfileModels;
using SteelProdBE.Models.OutputModels;

namespace SteelProdBE.Interfaces.IBusinessServices
{
    public interface IProfileServices
    {
        Task<ProfileSelectModel> Create(ProfileCreateModel dto);
        Task<ListViewModel<ProfileSelectModel>> Get(int currentPage, string? filterRequest, char? fromName, char? toName);
        Task<ProfileSelectModel> Update(ProfileUpdateModel dto);
        Task<ProfileSelectModel> GetById(int id);
        Task<Profile> Delete(int id);
    }
}
