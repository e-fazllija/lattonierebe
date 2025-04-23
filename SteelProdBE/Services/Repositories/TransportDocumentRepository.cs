using SteelProdBE.Data;
using SteelProdBE.Entities;
using SteelProdBE.Interfaces.IRepositories;

namespace SteelProdBE.Services.Repositories
{
    public class TransportDocumentRepository : GenericRepository<TransportDocument>, ITransportDocumentRepository
    {
        public TransportDocumentRepository(AppDbContext context) : base(context) { }
    }
}
