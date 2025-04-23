using SteelProdBE.Entities;
using SteelProdBE.Models.ProfileXmlModels;
using SteelProdBE.Models.OutputModels;

namespace SteelProdBE.Interfaces.IBusinessServices
{
    public interface IProfileXmlServices
    {
        Task<ProfileXmlSelectModel> Create(ProfileXmlCreateModel dto);
        Task<ListViewModel<ProfileXmlSelectModel>> Get(int currentPage, string? filterRequest, char? fromName, char? toName);
        Task<ProfileXmlSelectModel> Update(ProfileXmlUpdateModel dto);
        Task<ProfileXmlSelectModel> GetById(int id);
        Task<ProfileXml> Delete(int id);
    }
}
