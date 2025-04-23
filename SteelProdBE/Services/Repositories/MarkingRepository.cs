using SteelProdBE.Data;
using SteelProdBE.Entities;
using SteelProdBE.Interfaces.IRepositories;

namespace SteelProdBE.Services.Repositories
{
    public class MarkingRepository : GenericRepository<Marking>, IMarkingRepository
    {
        public MarkingRepository(AppDbContext context) : base(context) { }
    }
}
