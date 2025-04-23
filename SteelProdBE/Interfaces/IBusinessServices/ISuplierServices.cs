using SteelProdBE.Entities;
using SteelProdBE.Models.SupplierModels;
using SteelProdBE.Models.OutputModels;

namespace SteelProdBE.Interfaces.IBusinessServices
{
    public interface ISupplierServices
    {
        Task<SupplierSelectModel> Create(SupplierCreateModel dto);
        Task<ListViewModel<SupplierSelectModel>> Get(int currentPage, string? filterRequest, char? fromName, char? toName);
        Task<SupplierSelectModel> Update(SupplierUpdateModel dto);
        Task<SupplierSelectModel> GetById(int id);
        Task<Supplier> Delete(int id);
    }
}
