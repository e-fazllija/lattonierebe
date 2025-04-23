using System.Xml.Serialization;

namespace SteelProdBE.Entities.Xml
{
    [XmlRoot("job")]
    public class OperaMaterials : EntityBase
    {
        public int JobId { get; set; }
        [XmlElement("material")]
        public List<OperaMaterial>? OperaMaterial { get; set; }
    }

    public class OperaMaterial : EntityBase
    {
        public int OperaMaterialsId { get; set; }
        // NOME DEL MATERIALE 
        [XmlElement("mat_name")]
        public string? mat_name { get; set; }
        // Sistema Del Materiale
        [XmlElement("mat_system")]
        public string? mat_system { get; set; } // non evidenziato in verde
        // DESCRIZIONE DEL MATERIALE 
        [XmlElement("mat_description")]
        public string? mat_description { get; set; } // non evidenziato in verde
        // FUNZIONE DEL PROFILO
        [XmlElement("mat_profile_function_id")]
        public string? mat_profile_function_id { get; set; }
        // FUNZIONE DEL PROFILO
        [XmlElement("mat_profile_function")]
        public string? mat_profile_function { get; set; }
        // FUNZIONE DEL PROFILO
        [XmlElement("mat_profile_function2_id")]
        public string? mat_profile_function2_id { get; set; }
        // FUNZIONE DEL PROFILO
        [XmlElement("mat_profile_function2")]
        public string? mat_profile_function2 { get; set; }
        // FUNZIONE DEL PROFILO
        [XmlElement("mat_profile_function3_id")]
        public string? mat_profile_function3_id { get; set; }
        // FUNZIONE DEL PROFILO
        [XmlElement("mat_profile_function3")]
        public string? mat_profile_function3 { get; set; }
        [XmlElement("mat_alternative_code")]
        public string? mat_alternative_code { get; set; }
        [XmlElement("mat_supplier_code")]
        public string? mat_supplier_code { get; set; }
        [XmlElement("mat_quantity")]
        public string? mat_quantity { get; set; }
        [XmlElement("mat_quantity_on_unit")]
        public string? mat_quantity_on_unit { get; set; }
        [XmlElement("mat_width")]
        public string? mat_width { get; set; }
        [XmlElement("colors")]
        public OperaMaterialColors? OperaMaterialColors { get; set; }
        [XmlElement("cuts")]
        public OperaCuts? OperaCuts { get; set; }
    }
}
