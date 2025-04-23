using SteelProdBE.Data;
using SteelProdBE.Entities;
using SteelProdBE.Interfaces.IRepositories;

namespace SteelProdBE.Services.Repositories
{
    public class TransportComponentRepository : GenericRepository<TransportComponent>, ITransportComponentRepository
    {
        public TransportComponentRepository(AppDbContext context) : base(context) { }
    }
}
