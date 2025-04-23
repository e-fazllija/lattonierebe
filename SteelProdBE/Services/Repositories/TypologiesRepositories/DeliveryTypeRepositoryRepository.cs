using SteelProdBE.Data;
using SteelProdBE.Entities.Typologies;
using SteelProdBE.Interfaces.IRepositories.ITypologiesRepositories;
using SteelProdBE.Services.Repositories;

namespace SteelProdBE.Services.Repositories.TypologiesRepositories
{
    public class DeliveryTypeRepository : GenericRepository<DeliveryType>, IDeliveryTypeRepository
    {
        public DeliveryTypeRepository(AppDbContext context) : base(context) { }
    }
}
