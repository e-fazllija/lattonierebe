using SteelProdBE.Data;
using SteelProdBE.Entities.Typologies;
using SteelProdBE.Interfaces.IRepositories.ITypologiesRepositories;

namespace SteelProdBE.Services.Repositories.TypologiesRepositories
{
    public class AccessoryTypeRepository : GenericRepository<AccessoryType>, IAccessoryTypeRepository
    {
        public AccessoryTypeRepository(AppDbContext context) : base(context) { }
    }
}
