using SteelProdBE.Entities;
using SteelProdBE.Models.GoodReceiptModels;
using SteelProdBE.Models.OutputModels;

namespace SteelProdBE.Interfaces.IBusinessServices
{
    public interface IGoodReceiptServices
    {
        Task<GoodReceiptSelectModel> Create(GoodReceiptCreateModel dto);
        Task<ListViewModel<GoodReceiptSelectModel>> Get(int currentPage, int? filterRequest, DateTime? fromDate, DateTime? toDate);
        Task<GoodReceiptSelectModel> Update(GoodReceiptUpdateModel dto);
        Task<GoodReceiptSelectModel> GetById(int id);
        Task<GoodReceipt> Delete(int id);
        Task<ListViewModel<GoodModel>> GetStocks(int currentPage, string? filterRequest, int typeFilter, DateTime? fromDate, DateTime? toDate);
    }
}
