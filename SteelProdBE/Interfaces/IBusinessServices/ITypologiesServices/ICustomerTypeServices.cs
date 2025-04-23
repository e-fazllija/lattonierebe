using SteelProdBE.Entities.Typologies;
using SteelProdBE.Models.OutputModels;
using SteelProdBE.Models.TypologiesModels.CustomerTypeModels;

namespace SteelProdBE.Interfaces.IBusinessServices.ITypologiesServices
{
    public interface ICustomerTypeServices
    {
        Task<CustomerTypeSelectModel> Create(CustomerTypeCreateModel dto);
        Task<ListViewModel<CustomerTypeSelectModel>> Get(int currentPage, string? filterRequest);
        Task<CustomerTypeSelectModel> Update(CustomerTypeUpdateModel dto);
        Task<CustomerTypeSelectModel> GetById(int id);
        Task<CustomerType> Delete(int id);
    }
}
