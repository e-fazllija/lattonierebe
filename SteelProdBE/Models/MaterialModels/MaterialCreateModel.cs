using SteelProdBE.Entities.Typologies;
using SteelProdBE.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SteelProdBE.Models.MaterialModels
{
    public class MaterialCreateModel
    {
        public string Code { get; set; }  //| CODICE INTERNO
        public string SupplierArticleCode { get; set; } // | CODICE ARTICOLO FORNITORE
        public string Name { get; set; }
        public string? Description { get; set; } //| DESCRIZIONE ARTICOLO
        public string? UnitOfMeasure { get; set; } //| UNITA’ DI MISURA
        public string? Function { get; set; }
        public int? SupplierId { get; set; }
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
        public int? MaterialTypeId { get; set; } //| TIPOLOGIA
        public DateTime? LastDeliveryDate { get; set; } // | DATA ULTIMA CONSEGNA
        public DateTime CreationDate { get; set; } = DateTime.Now;

    }
}
