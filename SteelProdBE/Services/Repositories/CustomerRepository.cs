using SteelProdBE.Data;
using SteelProdBE.Entities;
using SteelProdBE.Interfaces.IRepositories;


namespace SteelProdBE.Services.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context){}
    }
}
