using SteelProdBE.Entities;
using SteelProdBE.Entities.Typologies;

namespace SteelProdBE.Models.SupplierModels
{
    public class SupplierSelectModel
    {
        public int Id { get; set; }
        public string Code { get; set; } // | CODICE
        public string UniqueCode { get; set; } // | CODICE UNIVOCO
        public string Name { get; set; } // | NOME
        public string? Address { get; set; } // | INDIRIZZO
        public string? ZipCode { get; set; } // | CAP
        public string? City { get; set; } // | CITTA’
        public string? Country { get; set; } // | NAZIONE
        public string? Province { get; set; } // | PROVINCIA
        public string? VATNumber { get; set; } // | P.IVA
        public string? FiscalCode { get; set; } // | CODICE FISCALE
        public string? ContactPerson { get; set; } // | REFERENTE
        public long? Phone { get; set; } // | TELEFONO
        public long? Mobile { get; set; } // | CELLULARE
        public string Email { get; set; } // | EMAIL
        public string? PEC { get; set; } // | PEC
        public string? Fax { get; set; } // | FAX
        public string? ReferenceAgent { get; set; } // | AGENTE DI RIFERIMENTO
        public int? PaymentTypeId { get; set; } // | MODALITA’ DI PAGAMENTO
        public virtual PaymentType PaymentType { get; set; } = new PaymentType(); // Relazione con la tabella delle modalità di pagamento
        public string? BankDetails { get; set; } // | COORDINATE BANCARIE
        public string? Notes { get; set; } // | NOTE
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
