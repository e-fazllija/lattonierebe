using SteelProdBE.Entities;
using SteelProdBE.Models.AccessoryModels;
using SteelProdBE.Models.MarkingModels;
using SteelProdBE.Models.OutputModels;

namespace SteelProdBE.Interfaces.IBusinessServices
{
    public interface IMarkingServices
    {
        Task<MarkingSelectModel> Create(MarkingCreateModel dto);
        Task<ListViewModel<MarkingSelectModel>> Get(int currentPage, string? filterRequest, char? fromName, char? toName);
        Task<MarkingSelectModel> Update(MarkingUpdateModel dto);
        Task<MarkingSelectModel> GetById(int id);
        Task<Marking> Delete(int id);
    }
}
