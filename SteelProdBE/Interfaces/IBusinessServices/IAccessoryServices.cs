using SteelProdBE.Entities;
using SteelProdBE.Models.AccessoryModels;
using SteelProdBE.Models.OutputModels;

namespace SteelProdBE.Interfaces.IBusinessServices
{
    public interface IAccessoryServices
    {
        Task<AccessorySelectModel> Create(AccessoryCreateModel dto);
        Task<ListViewModel<AccessorySelectModel>> Get(int currentPage, string? filterRequest, char? fromName, char? toName);
        Task<AccessorySelectModel> Update(AccessoryUpdateModel dto);
        Task<AccessorySelectModel> GetById(int id);
        Task<Accessory> Delete(int id);
    }
}
