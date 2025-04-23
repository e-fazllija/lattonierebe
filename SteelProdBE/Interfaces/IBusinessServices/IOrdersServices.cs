using SteelProdBE.Entities;
using SteelProdBE.Models.OutputModels;
using SteelProdBE.Models.Xml.XmlUpdateModels;
using SteelProdBE.Models.Xml.XmlSelectModels;
using SteelProdBE.Models.Xml.XmlCreateModels;
using SteelProdBE.Models.XmlFileListModels;
using System.Xml.Linq;

namespace SteelProdBE.Interfaces.IBusinessServices
{
    public interface IOrdersServices
    {
        Task<XmlOperaSelectModel> Create(XmlOperaCreateModel dto);
        Task<ListViewModel<XmlOperaSelectModel>> Get(int currentPage, string? filterRequest, char? fromName, char? toName);
        Task<XmlOperaSelectModel> Update(XmlOperaUpdateModel dto);
        Task<XmlOperaSelectModel> GetById(int id);
        Task<XmlOpera> Delete(int id);
        Task<List<XElement>> CreateXmlFileList(XmlFileListCreateModel dto);
        Task<XmlFileListCreateModel> GetDataForXmlFile(int id);
    }
}
