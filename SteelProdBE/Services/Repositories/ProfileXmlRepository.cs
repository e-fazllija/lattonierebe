using SteelProdBE.Data;
using SteelProdBE.Entities;
using SteelProdBE.Interfaces.IRepositories;


namespace SteelProdBE.Services.Repositories
{
    public class ProfileXmlRepository : GenericRepository<ProfileXml>, IProfileXmlRepository
    {
        public ProfileXmlRepository(AppDbContext context) : base(context){}
    }
}
