using SteelProdBE.Entities;
using SteelProdBE.Models.MaterialModels;
using SteelProdBE.Models.OutputModels;

namespace SteelProdBE.Interfaces.IBusinessServices
{
    public interface IMaterialServices
    {
        Task<MaterialSelectModel> Create(MaterialCreateModel dto);
        Task<ListViewModel<MaterialSelectModel>> Get(int currentPage, string? filterRequest, char? fromName, char? toName);
        Task<MaterialSelectModel> Update(MaterialUpdateModel dto);
        Task<MaterialSelectModel> GetById(int id);
        Task<Material> Delete(int id);
    }
}
