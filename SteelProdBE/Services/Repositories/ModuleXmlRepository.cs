using SteelProdBE.Data;
using SteelProdBE.Entities;
using SteelProdBE.Interfaces.IRepositories;

namespace SteelProdBE.Services.Repositories
{
    public class ModuleXmlRepository : GenericRepository<ModuleXml>, IModuleXmlRepository
    {
        public ModuleXmlRepository(AppDbContext context) : base(context) { }
    }
}
