using SteelProdBE.Data;
using SteelProdBE.Entities.Typologies;
using SteelProdBE.Interfaces.IRepositories.ITypologiesRepositories;
using SteelProdBE.Services.Repositories;

namespace SteelProdBE.Services.Repositories.TypologiesRepositories
{
    public class ProfileTypeRepository : GenericRepository<ProfileType>, IProfileTypeRepository
    {
        public ProfileTypeRepository(AppDbContext context) : base(context) { }
    }
}
