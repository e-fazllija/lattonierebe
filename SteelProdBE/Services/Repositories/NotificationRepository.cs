using SteelProdBE.Data;
using SteelProdBE.Entities;
using SteelProdBE.Interfaces.IRepositories;

namespace SteelProdBE.Services.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(AppDbContext context) : base(context){}
    }
}
