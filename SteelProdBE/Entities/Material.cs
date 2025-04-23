using SteelProdBE.Entities.Typologies;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SteelProdBE.Entities
{
    public class Material : EntityBase
    {
        public string Code { get; set; }  //| CODICE INTERNO 
        public string SupplierArticleCode { get; set; } // | CODICE ARTICOLO FORNITORE
        public string Name { get; set; }
        public string? Description { get; set; } //| DESCRIZIONE ARTICOLO
        public string? UnitOfMeasure { get; set; } //| UNITA’ DI MISURA
        public string? Function { get; set; }
        public int? SupplierId { get; set; }
        public virtual Supplier? Supplier { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? UnitPrice { get; set; } //| PREZZO UNITARIO
        [Column(TypeName = "decimal(18,4)")]
        public decimal? PackagingQuantity { get; set; } //| QUANTITA’ CONFEZIONE
        [Column(TypeName = "decimal(18,4)")]
        public decimal? MinimumStock { get; set; } //| GIACENZA MINIMA
        [Column(TypeName = "decimal(18,4)")]
        public decimal? Quantity { get; set; }
        public string? Photo { get; set; }
        public string? DeliveryTiming { get; set; } //| TEMPISTICHE DI CONSEGNA
        public int? DeliveryTypeId { get; set; } //| MODALITA’ DI CONSEGNA
        public virtual DeliveryType? DeliveryType { get; set; }
        public int? MaterialTypeId { get; set; } //| TIPOLOGIA
        public  virtual MaterialType? MaterialType { get; set; } //| TIPOLOGIA
        public DateTime? LastDeliveryDate { get; set; } // | DATA ULTIMA CONSEGNA
    }
}
