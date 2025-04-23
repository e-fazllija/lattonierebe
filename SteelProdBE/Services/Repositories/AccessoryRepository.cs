using SteelProdBE.Data;
using SteelProdBE.Entities;
using SteelProdBE.Interfaces.IRepositories;

namespace SteelProdBE.Services.Repositories
{
    public class AccessoryRepository : GenericRepository<Accessory>, IAccessoryRepository
    {
        public AccessoryRepository(AppDbContext context) : base(context){}
    }
}
