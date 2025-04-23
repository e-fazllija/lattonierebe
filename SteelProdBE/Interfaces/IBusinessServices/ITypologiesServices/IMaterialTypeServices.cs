using SteelProdBE.Entities.Typologies;
using SteelProdBE.Models.OutputModels;
using SteelProdBE.Models.TypologiesModels.MaterialTypeModels;

namespace SteelProdBE.Interfaces.IBusinessServices.ITypologiesServices
{
    public interface IMaterialTypeServices
    {
        Task<MaterialTypeSelectModel> Create(MaterialTypeCreateModel dto);
        Task<ListViewModel<MaterialTypeSelectModel>> Get(int currentPage, string? filterRequest);
        Task<MaterialTypeSelectModel> Update(MaterialTypeUpdateModel dto);
        Task<MaterialTypeSelectModel> GetById(int id);
        Task<MaterialType> Delete(int id);
    }
}
