using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SteelProdBE.Entities;
using SteelProdBE.Entities.Xml;
using System.Text.RegularExpressions;
using SteelProdBE.Entities.Typologies;
using SteelProdBE.Services;

namespace SteelProdBE.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Marking> Markings { get; set; }
        public DbSet<AccessoryType> AccessoryTypes { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<DeliveryType> DeliveryTypes { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<ProfileType> ProfileTypes { get; set; }
        public DbSet<XmlOpera> XmlOpera { get; set; }
        public DbSet<GoodReceipt> GoodReceipts { get; set; }
        public DbSet<TransportDocument> TransportDocuments { get; set; }
        public DbSet<ModuleXml> ModulesXml { get; set; }
        public DbSet<GoodReceiptType> GoodReceiptTypes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<TransportComponent> TransportComponents { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderRequests> OrderRequests { get; set; }
        //public DbSet<QuoteRequests> QuoteRequests { get; set; }
        public DbSet<ProfileXml> ProfilesXml { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Bpf> Bpfs { get; set; }
        public DbSet<ProTubeJobs> ProTubeJobs { get; set; }

        #region "Opera"
        public DbSet<Job> Job { get; set; }
        public DbSet<OperaJobCustomer> OperaJobCustomer { get; set; }
        public DbSet<OperaJobComponents> OperaJobComponents { get; set; }
        public DbSet<OperaComponent> OperaComponent { get; set; }
        public DbSet<OperaColors> OperaColors { get; set; }
        public DbSet<OperaColor> OperaColor { get; set; }
        public DbSet<OperaMaterials> OperaMaterials { get; set; }
        public DbSet<OperaMaterial> OperaMaterial { get; set; }
        public DbSet<OperaMaterialColors> OperaMaterialColors { get; set; }
        public DbSet<OperaMaterialColor> OperaMaterialColor { get; set; }
        public DbSet<OperaCuts> OperaCuts { get; set; }
        public DbSet<OperaCut> OperaCut { get; set; }
        public DbSet<OperaMachinings> OperaMachinings { get; set; }
        public DbSet<OperaMachining> OperaMachining { get; set; }
        #endregion

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureEntities();

        }
    }
}
