using SteelProdBE.Data;
using SteelProdBE.Entities;
using SteelProdBE.Interfaces.IRepositories;

namespace SteelProdBE.Services.Repositories
{
    public class GoodReceiptRepository : GenericRepository<GoodReceipt>, IGoodReceiptRepository
    {
        public GoodReceiptRepository(AppDbContext context) : base(context) { }
    }
}
