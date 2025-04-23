using SteelProdBE.Entities.Typologies;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SteelProdBE.Entities
{
    public class Profile: EntityBase
    {
        public int? ProfileTypeId { get; set; } //– TIPOLOGIA
        public virtual ProfileType? ProfileType { get; set; }
        public string Code { get; set; } // | CODICE INTERNO
        public string SupplierArticleCode { get; set; } // | CODICE ARTICOLO FORNITORE
        public string Name { get; set; } // | NOME
        public string? Description { get; set; } // | DESCRIZIONE ARTICOLO
        public string? UnitOfMeasure { get; set; } // | UNITÀ DI MISURA
        public int? SupplierId { get; set; } // | ID FORNITORE
        public virtual Supplier Supplier { get; set; } // Relazione con la tabella dei fornitori
        [Column(TypeName = "decimal(18,4)")]
        public decimal? Price { get; set; } // | PREZZO UNITARIO
        [Column(TypeName = "decimal(18,4)")]
        public decimal? PackageQuantity { get; set; } // | QUANTITÀ CONFEZIONE
        [Column(TypeName = "decimal(18,4)")]
        public decimal? MinimumStock { get; set; } // | GIACENZA MINIMA
        [Column(TypeName = "decimal(18,4)")]
        public decimal? Quantity { get; set; } // | QUANTITÀ
        public string? Photo { get; set; } // | FOTO
        public string? DeliveryTimeframe { get; set; } // | TEMPISTICHE DI CONSEGNA
        public int? DeliveryTypeId { get; set; } // | ID TIPOLOGIA CONSEGNA
        public virtual DeliveryType? DeliveryType { get; set; } // Relazione con la tabella delle modalità di consegna
        public DateTime? LastDeliveryDate { get; set; } // | DATA ULTIMA CONSEGNA
    }
}
