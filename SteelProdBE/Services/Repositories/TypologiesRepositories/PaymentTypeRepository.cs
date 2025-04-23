using SteelProdBE.Data;
using SteelProdBE.Entities.Typologies;
using SteelProdBE.Interfaces.IRepositories.ITypologiesRepositories;
using SteelProdBE.Services.Repositories;

namespace SteelProdBE.Services.Repositories.TypologiesRepositories
{
    public class PaymentTypeRepository : GenericRepository<PaymentType>, IPaymentTypeRepository
    {
        public PaymentTypeRepository(AppDbContext context) : base(context) { }
    }
}
