using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using SteelProdBE.Data;
using SteelProdBE.Interfaces.IRepositories;
using SteelProdBE.Interfaces.IRepositories.ITypologiesRepositories;

namespace SteelProdBE.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        AppDbContext dbContext { get; }
        ICustomerRepository CustomerRepository { get; }
        IAccessoryRepository AccessoryRepository { get; }
        IProfileRepository ProfileRepository { get; }
        ISupplierRepository SupplierRepository { get; }
        IMaterialRepository MaterialRepository { get; }
        ICustomerTypeRepository CustomerTypeRepository { get; } 
        IMaterialTypeRepository MaterialTypeRepository { get; }
        IDeliveryTypeRepository DeliveryTypeRepository { get; }
        IPaymentTypeRepository PaymentTypeRepository { get; }
        IProfileTypeRepository ProfileTypeRepository { get; }
        IXmlOperaRepository XmlOperaRepository { get; }
        IGoodReceiptRepository GoodReceiptRepository { get; }
        ITransportDocumentRepository TransportDocumentRepository { get; }
        IModuleXmlRepository ModuleXmlRepository { get; }
        IMarkingRepository MarkingRepository { get; }
        IGoodReceiptTypeRepository GoodReceiptTypeRepository { get; }
        INotificationRepository NotificationRepository { get; }
        ITransportComponentRepository TransportComponentRepository { get; }
        IAccessoryTypeRepository AccessoryTypeRepository { get; }
        //IOrdersRepository OrdersRepository { get; }
        //IOrderRequestsRepository OrderRequestsRepository { get; }
        //IQuoteRequestsRepository QuoteRequestsRepository { get; }
        IProfileXmlRepository ProfileXmlRepository { get; }
        IBpfsRepository BpfsRepository { get; }
        Task<int> SaveAsync();
        int Save();

    }
}