using SteelProdBE.Entities;
using SteelProdBE.Models.CustomerModels;
using SteelProdBE.Models.OutputModels;

namespace SteelProdBE.Interfaces.IBusinessServices
{
    public interface ICustomerServices
    {
        Task<CustomerSelectModel> Create(CustomerCreateModel dto);
        Task<ListViewModel<CustomerSelectModel>> Get(int currentPage, string? filterRequest, char? fromName, char? toName);
        Task<CustomerSelectModel> Update(CustomerUpdateModel dto);
        Task<CustomerSelectModel> GetById(int id);
        Task<Customer> Delete(int id);
    }
}
