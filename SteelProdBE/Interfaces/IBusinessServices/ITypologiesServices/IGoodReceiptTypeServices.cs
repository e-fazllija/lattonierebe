using SteelProdBE.Entities.Typologies;
using SteelProdBE.Models.OutputModels;
using SteelProdBE.Models.TypologiesModels.AccessoryTypeModels;
using SteelProdBE.Models.TypologiesModels.GoodReceiptTypeModels;

namespace SteelProdBE.Interfaces.IBusinessServices.ITypologiesServices
{
    public interface IGoodReceiptTypeServices
    {
        Task<ListViewModel<GoodReceiptTypeSelectModel>> Get(int currentPage, string? filterRequest);
        Task<GoodReceiptTypeSelectModel> GetById(int id);
        Task<GoodReceiptTypeSelectModel> Create(GoodReceiptTypeCreateModel dto);
        Task<GoodReceiptType> Delete(int id);
        Task<GoodReceiptTypeSelectModel> Update(GoodReceiptTypeUpdateModel dto);

    }
}
