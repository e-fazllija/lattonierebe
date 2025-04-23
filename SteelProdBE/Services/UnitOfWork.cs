using SteelProdBE.Data;
using SteelProdBE.Interfaces;
using SteelProdBE.Interfaces.IRepositories;
using SteelProdBE.Interfaces.IRepositories.ITypologiesRepositories;
using SteelProdBE.Services.Repositories;
using SteelProdBE.Services.Repositories.TypologiesRepositories;

namespace SteelProdBE.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public AppDbContext dbContext { get; set; }
        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
            this.dbContext = context;

            CustomerRepository = new CustomerRepository(this._context);
            AccessoryRepository = new AccessoryRepository(this._context);
            ProfileRepository = new ProfileRepository(this._context);
            SupplierRepository = new SupplierRepository(this._context);
            MaterialRepository = new MaterialRepository(this._context);
            CustomerTypeRepository = new CustomerTypeRepository(this._context);
            MaterialTypeRepository = new MaterialTypeRepository(this._context);
            DeliveryTypeRepository = new DeliveryTypeRepository(this._context);
            PaymentTypeRepository = new PaymentTypeRepository(this._context);
            ProfileTypeRepository = new ProfileTypeRepository(this._context);
            XmlOperaRepository = new XmlOperaRepository(this._context);
            GoodReceiptRepository = new GoodReceiptRepository(this._context);
            TransportDocumentRepository = new TransportDocumentRepository(this._context);
            ModuleXmlRepository = new ModuleXmlRepository(this._context);
            MarkingRepository = new MarkingRepository(this._context);
            GoodReceiptTypeRepository = new GoodReceiptTypeRepository(this._context);
            NotificationRepository = new NotificationRepository(this._context);
            TransportComponentRepository = new TransportComponentRepository(this._context);
            AccessoryTypeRepository = new AccessoryTypeRepository(this._context);
            //OrdersRepository = new OrdersRepository(this._context);
            //OrderRequestsRepository = new OrderRequestsRepository(this._context);
            //QuoteRequestsRepository = new QuoteRequestsRepository(this._context);
            ProfileXmlRepository = new ProfileXmlRepository(this._context);
            BpfsRepository = new BpfsRepository(this._context);
        }

      
        public ICustomerRepository CustomerRepository
        {
            get;
            private set;
        }
        public IAccessoryRepository AccessoryRepository
        {
            get;
            private set;
        }
        public IProfileRepository ProfileRepository
        {
            get;
            private set;
        }
        public ISupplierRepository SupplierRepository
        {
            get;
            private set;
        }
        public IMaterialRepository MaterialRepository
        {
            get;
            private set;
        }
        public ICustomerTypeRepository CustomerTypeRepository
        {
            get;
            private set;
        }
        public IMaterialTypeRepository MaterialTypeRepository
        {
            get;
            private set;
        }
        public IDeliveryTypeRepository DeliveryTypeRepository
        {
            get;
            private set;
        }
        public IPaymentTypeRepository PaymentTypeRepository
        {
            get;
            private set;
        }
        public IProfileTypeRepository ProfileTypeRepository
        {
            get;
            private set;
        }
        public IXmlOperaRepository XmlOperaRepository
        {
            get;
            private set;
        }
        public IGoodReceiptRepository GoodReceiptRepository
        {
            get;
            private set;
        }

        public ITransportDocumentRepository TransportDocumentRepository
        {
            get;
            private set;
        }

        public IModuleXmlRepository ModuleXmlRepository
        {
            get;
            private set;
        }

        public IMarkingRepository MarkingRepository
        {
            get;
            private set;
        }

        public IGoodReceiptTypeRepository GoodReceiptTypeRepository
        {
            get;
            private set;
        }
        public INotificationRepository NotificationRepository
        {
            get;
            private set;
        }
        public ITransportComponentRepository TransportComponentRepository
        {
            get;
            private set;
        }
        public IAccessoryTypeRepository AccessoryTypeRepository
        {
            get;
            private set;
        }
        
        //public IOrdersRepository OrdersRepository
        //{
        //    get;
        //    private set;
        //}

        //public IOrderRequestsRepository OrderRequestsRepository
        //{
        //    get;
        //    private set;
        //}

        //public IQuoteRequestsRepository QuoteRequestsRepository
        //{
        //    get;
        //    private set;
        //}

        public IProfileXmlRepository ProfileXmlRepository
        {
            get;
            private set;
        }

        public IBpfsRepository BpfsRepository
        {
            get;
            private set;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();

        }

        public int Save()
        {
            return  _context.SaveChanges();

        }
    }
}