using SteelProdBE.Entities.Typologies;
using SteelProdBE.Entities;

namespace SteelProdBE.Models.AccessoryModels
{
    public class AccessorySelectModel
    {
        public int Id { get; set; }
        public int AccessoryTypeId { get; set; } = 0; // | ID TIPOLOGIA ACCESSORIO
        public string Code { get; set; } = string.Empty;// | CODICE INTERNO
        public string SupplierArticleCode { get; set; } = string.Empty;// | CODICE ARTICOLO FORNITORE
        public string Name { get; set; } = string.Empty;// | NOME
        public string Description { get; set; } = string.Empty; // | DESCRIZIONE ARTICOLO
        public string UnitOfMeasure { get; set; } = string.Empty;// | UNITÀ DI MISURA
        public int SupplierId { get; set; } = 0;// | ID FORNITORE
        public decimal Price { get; set; } = 0;// | PREZZO UNITARIO
        public decimal PackageQuantity { get; set; } = 0;// | QUANTITÀ CONFEZIONE
        public decimal MinimumStock { get; set; } = 0;// | GIACENZA MINIMA
        public decimal Quantity { get; set; } = 0;// | QUANTITÀ
        public string Photo { get; set; } = string.Empty;// | FOTO
        public string DeliveryTimeframe { get; set; } = string.Empty; // | TEMPISTICHE DI CONSEGNA
        public int DeliveryTypeId { get; set; } = 0;// | ID TIPOLOGIA CONSEGNA
        public virtual AccessoryType AccessoryType { get; set; } = new AccessoryType();
        public virtual Supplier Supplier { get; set; } = new Supplier();
        public virtual DeliveryType DeliveryType { get; set; } = new DeliveryType();
        public DateTime LastDeliveryDate { get; set; } = DateTime.MinValue;// | DATA ULTIMA CONSEGNA
        public DateTime CreationDate { get; set; } = DateTime.MinValue;
        public DateTime UpdateDate { get; set; } = DateTime.MinValue;
    }
}
