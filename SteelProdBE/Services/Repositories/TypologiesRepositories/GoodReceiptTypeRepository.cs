using SteelProdBE.Data;
using SteelProdBE.Entities.Typologies;
using SteelProdBE.Interfaces.IRepositories.ITypologiesRepositories;
using SteelProdBE.Services.Repositories;

namespace SteelProdBE.Services.Repositories.TypologiesRepositories
{
    public class GoodReceiptTypeRepository : GenericRepository<GoodReceiptType>, IGoodReceiptTypeRepository
    {
        public GoodReceiptTypeRepository(AppDbContext context) : base(context) { }
    }
}
