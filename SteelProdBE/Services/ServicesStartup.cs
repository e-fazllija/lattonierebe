using Carpenteria.Api.Services.BusinessServices;
using SteelProdBE.Interfaces;
using SteelProdBE.Interfaces.IBusinessServices;
using SteelProdBE.Interfaces.IBusinessServices.ITypologiesServices;
using SteelProdBE.Services.BusinessServices;
using SteelProdBE.Services.BusinessServices.TypologiesServices;

namespace SteelProdBE.Services
{
    public static class ServicesStartup
    {

      
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {

            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<IAccessoryServices, AccessoryServices>();
            builder.Services.AddTransient<IAccessoryTypeServices, AccessoryTypeServices>();
            builder.Services.AddTransient<ICustomerTypeServices, CustomerTypeServices>();
            builder.Services.AddTransient<ICustomerServices, CustomerServices>();
            builder.Services.AddTransient<IDeliveryTypeServices, DeliveryTypeServices>();
            builder.Services.AddTransient<IGoodReceiptTypeServices, GoodReceiptTypeServices>();
            builder.Services.AddTransient<IMarkingServices, MarkingServices>();
            builder.Services.AddTransient<IMaterialTypeServices, MaterialTypeServices>();
            builder.Services.AddTransient<IModuleXmlServices, ModuleXmlServices>();
            builder.Services.AddTransient<IMaterialServices, MaterialServices>();
            builder.Services.AddTransient<IOrdersServices, OrdersServices>();
            builder.Services.AddTransient<IPaymentTypeServices, PaymentTypeServices>();
            builder.Services.AddTransient<IProfileTypeServices, ProfileTypeServices>();
            builder.Services.AddTransient<IProfileServices, ProfileServices>();
            builder.Services.AddTransient<ISupplierServices, SupplierServices>();
            builder.Services.AddTransient<IProfileXmlServices, ProfileXmlServices>();
            builder.Services.AddTransient<IGoodReceiptServices, GoodReceiptServices>();
        }
    }
}