using SteelProdBE.Entities.Typologies;
using SteelProdBE.Models.OutputModels;
using SteelProdBE.Models.TypologiesModels.DeliveryTypeModels;

namespace SteelProdBE.Interfaces.IBusinessServices.ITypologiesServices
{
    public interface IDeliveryTypeServices
    {
        Task<DeliveryTypeSelectModel> Create(DeliveryTypeCreateModel dto);
        Task<ListViewModel<DeliveryTypeSelectModel>> Get(int currentPage, string? filterRequest);
        Task<DeliveryTypeSelectModel> Update(DeliveryTypeUpdateModel dto);
        Task<DeliveryTypeSelectModel> GetById(int id);
        Task<DeliveryType> Delete(int id);
    }
}
