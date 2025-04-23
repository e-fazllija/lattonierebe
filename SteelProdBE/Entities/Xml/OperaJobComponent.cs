using System.Xml.Serialization;

namespace SteelProdBE.Entities.Xml
{
    [XmlRoot("job")]
    public class OperaJobComponents : EntityBase
    {
        public int JobId { get; set; }
        [XmlElement("component")]
        public List<OperaComponent>? OperaComponent { get; set; }
    }

    public class OperaComponent : EntityBase
    {
        public int OperaJobComponentsId { get; set; }
        // IDENTIFICATIVO CODICE
        [XmlElement("cmp_idcode")]
        public string? cmp_idcode { get; set; }
        // Quantita
        [XmlElement("cmp_quantity")]
        public string? cmp_quantity { get; set; }
        // Tipologia
        [XmlElement("cmp_category")]
        public string? cmp_category { get; set; }
        // Sistema
        [XmlElement("cmp_system")]
        public string? cmp_system { get; set; }
        // Serie
        [XmlElement("cmp_series")]
        public string? cmp_series { get; set; }
        // Larghezza mm
        [XmlElement("cmp_width")]
        public string? cmp_width { get; set; }
        // Altezza mm
        [XmlElement("cmp_height")]
        public string? cmp_height { get; set; }
        // ----
        [XmlElement("cmp_name")]
        public string? cmp_name { get; set; }
        // Descrizione
        [XmlElement("cmp_description")]
        public string? cmp_description { get; set; }
        // Prezzo
        [XmlElement("cmp_price")]
        public string? cmp_price { get; set; }
        // Iva
        [XmlElement("cmp_vat_rate")]
        public string? cmp_vat_rate { get; set; }
        [XmlElement("cmp_panes")]
        public string? cmp_panes { get; set; }
        // Qualita
        [XmlElement("colors")]
        public OperaColors? OperaColors { get; set; }
    }
}
