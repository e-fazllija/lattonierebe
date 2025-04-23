using SteelProdBE.Data;
using SteelProdBE.Entities.Typologies;
using SteelProdBE.Interfaces.IRepositories.ITypologiesRepositories;
using SteelProdBE.Services.Repositories;

namespace SteelProdBE.Services.Repositories.TypologiesRepositories
{
    public class MaterialTypeRepository : GenericRepository<MaterialType>, IMaterialTypeRepository
    {
        public MaterialTypeRepository(AppDbContext context) : base(context) { }
    }
}
