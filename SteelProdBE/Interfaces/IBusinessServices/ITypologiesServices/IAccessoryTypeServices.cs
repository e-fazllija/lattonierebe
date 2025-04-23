using SteelProdBE.Entities.Typologies;
using SteelProdBE.Models.OutputModels;
using SteelProdBE.Models.TypologiesModels.AccessoryTypeModels;

namespace SteelProdBE.Interfaces.IBusinessServices.ITypologiesServices
{
    public interface IAccessoryTypeServices
    {
        Task<AccessoryTypeSelectModel> Create(AccessoryTypeCreateModel dto);
        Task<ListViewModel<AccessoryTypeSelectModel>> Get(int currentPage, string? filterRequest);
        Task<AccessoryTypeSelectModel> Update(AccessoryTypeUpdateModel dto);
        Task<AccessoryTypeSelectModel> GetById(int id);
        Task<AccessoryType> Delete(int id);
    }
}
