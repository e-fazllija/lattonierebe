using SteelProdBE.Entities.Typologies;
using SteelProdBE.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SteelProdBE.Models.MaterialModels
{
    public class MaterialSelectModel
    {
        public int Id { get; set; }
        public string Code { get; set; }  //| CODICE INTERNO
        public string SupplierArticleCode { get; set; } // | CODICE ARTICOLO FORNITORE
        public string Name { get; set; }
        public string? Description { get; set; } //| DESCRIZIONE ARTICOLO
        public string? UnitOfMeasure { get; set; } //| UNITA’ DI MISURA
        public string? Function { get; set; }
        public int? SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } = new Supplier();
        public decimal? UnitPrice { get; set; } //| PREZZO UNITARIO
        public decimal? PackagingQuantity { get; set; } //| QUANTITA’ CONFEZIONE
        public decimal? MinimumStock { get; set; } //| GIACENZA MINIMA
        public decimal? Quantity { get; set; }
        public string? Photo { get; set; }
        public string? DeliveryTiming { get; set; } //| TEMPISTICHE DI CONSEGNA
        public int? DeliveryTypeId { get; set; } //| MODALITA’ DI CONSEGNA
        public virtual DeliveryType DeliveryType { get; set; } = new DeliveryType();
        public int? MaterialTypeId { get; set; } //| TIPOLOGIA
        public virtual MaterialType MaterialType { get; set; } = new MaterialType(); //| TIPOLOGIA
        public DateTime? LastDeliveryDate { get; set; } // | DATA ULTIMA CONSEGNA
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
