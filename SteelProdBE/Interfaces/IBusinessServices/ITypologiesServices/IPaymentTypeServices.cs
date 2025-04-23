using SteelProdBE.Entities.Typologies;
using SteelProdBE.Models.OutputModels;
using SteelProdBE.Models.TypologiesModels.PaymentTypeModels;

namespace SteelProdBE.Interfaces.IBusinessServices.ITypologiesServices
{
    public interface IPaymentTypeServices
    {
        Task<PaymentTypeSelectModel> Create(PaymentTypeCreateModel dto);
        Task<ListViewModel<PaymentTypeSelectModel>> Get(int currentPage, string? filterRequest);
        Task<PaymentTypeSelectModel> Update(PaymentTypeUpdateModel dto);
        Task<PaymentTypeSelectModel> GetById(int id);
        Task<PaymentType> Delete(int id);
    }
}
