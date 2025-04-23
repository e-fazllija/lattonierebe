using SteelProdBE.Entities;
using SteelProdBE.Models.ModuleXmlModels;
using SteelProdBE.Models.OutputModels;

namespace SteelProdBE.Interfaces.IBusinessServices
{
    public interface IModuleXmlServices
    {
        Task<ModuleXmlSelectModel> Create(ModuleXmlCreateModel dto);
        Task<ListViewModel<ModuleXmlSelectModel>> Get(int currentPage, string? filterRequest, char? fromName, char? toName);
        Task<ModuleXmlSelectModel> Update(ModuleXmlUpdateModel dto);
        Task<ModuleXmlSelectModel> GetById(int id);
        Task<ModuleXml> Delete(int id);
    }
}
