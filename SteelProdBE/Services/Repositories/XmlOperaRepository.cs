using SteelProdBE.Data;
using SteelProdBE.Entities;
using SteelProdBE.Interfaces.IRepositories;

namespace SteelProdBE.Services.Repositories
{
    public class XmlOperaRepository : GenericRepository<XmlOpera>, IXmlOperaRepository
    {
        public XmlOperaRepository(AppDbContext context) : base(context) { }
    }
}
