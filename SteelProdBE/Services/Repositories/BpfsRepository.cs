using SteelProdBE.Data;
using SteelProdBE.Entities.Xml;
using SteelProdBE.Interfaces.IRepositories;


namespace SteelProdBE.Services.Repositories
{
    public class BpfsRepository : GenericRepository<Bpf>, IBpfsRepository
    {
        public BpfsRepository(AppDbContext context) : base(context){}
    }
}
