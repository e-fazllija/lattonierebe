using SteelProdBE.Entities.Typologies;
using SteelProdBE.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SteelProdBE.Models.ProfileModels
{
    public class ProfileUpdateModel
    {
        public int Id { get; set; }
        public int? ProfileTypeId { get; set; } //– TIPOLOGIA
        public string Code { get; set; } // | CODICE INTERNO
        public string SupplierArticleCode { get; set; } // | CODICE ARTICOLO FORNITORE
        public string Name { get; set; } // | NOME
        public string? Description { get; set; } // | DESCRIZIONE ARTICOLO
        public string? UnitOfMeasure { get; set; } // | UNITÀ DI MISURA
        public int? SupplierId { get; set; } // | ID FORNITORE
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
        public DateTime? LastDeliveryDate { get; set; } // | DATA ULTIMA CONSEGNA
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
