using SteelProdBE.Entities.Typologies;
using SteelProdBE.Entities;

namespace SteelProdBE.Models.AccessoryModels
{
    public class AccessoryCreateModel
    {
        public int? AccessoryTypeId { get; set; } // | ID TIPOLOGIA ACCESSORIO
        public string Code { get; set; } // | CODICE INTERNO
        public string SupplierArticleCode { get; set; } // | CODICE ARTICOLO FORNITORE
        public string Name { get; set; } // | NOME
        public string? Description { get; set; } // | DESCRIZIONE ARTICOLO
        public string? UnitOfMeasure { get; set; } // | UNITÀ DI MISURA
        public int? SupplierId { get; set; } // | ID FORNITORE
        public decimal? Price { get; set; } // | PREZZO UNITARIO
        public decimal? PackageQuantity { get; set; } // | QUANTITÀ CONFEZIONE
        public decimal? MinimumStock { get; set; } // | GIACENZA MINIMA
        public decimal? Quantity { get; set; } // | QUANTITÀ
        public string? Photo { get; set; } // | FOTO
        public string? DeliveryTimeframe { get; set; } // | TEMPISTICHE DI CONSEGNA
        public int? DeliveryTypeId { get; set; } // | ID TIPOLOGIA CONSEGNA
        public DateTime? LastDeliveryDate { get; set; } // | DATA ULTIMA CONSEGNA
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
