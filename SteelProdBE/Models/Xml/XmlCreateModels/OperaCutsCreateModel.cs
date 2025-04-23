using SteelProdBE.Entities.Xml;
using SteelProdBE.Entities;
using System.Xml.Serialization;

namespace SteelProdBE.Models.Xml.XmlCreateModels
{
    [XmlRoot("cuts")]

    public class OperaCutsCreateModel
    {
        public int OperaMaterialId { get; set; }
        [XmlElement("cut")]
        public List<OperaCutCreateModel>? OperaCut { get; set; }
    }

    public class OperaCutCreateModel
    {
        public int OperaCutsId { get; set; }
        // ID taglio es. 450.01
        [XmlElement("cut_idcode")]
        public string? cut_idcode { get; set; }
        // Pezzi tagliati
        [XmlElement("cut_pieces")]
        public string? cut_pieces { get; set; }   //non evidenziata
        // TAGLIO ESTERNO
        [XmlElement("cut_lenght_external")]
        public string? cut_lenght_external { get; set; }
        // TAGLIO INTERNO
        [XmlElement("cut_lenght_internal")]
        public string? cut_lenght_internal { get; set; }
        // LUNGHEZZA MASSIMA
        [XmlElement("cut_lenght_max")]
        public string? cut_lenght_max { get; set; }
        // Lunghezza del tubo
        [XmlElement("cut_lenght_tube")]
        public string? cut_lenght_tube { get; set; }
        // Ingombro
        [XmlElement("cut_lenght_encumbrance")]
        public string? cut_lenght_encumbrance { get; set; }
        // Angolo sx
        [XmlElement("cut_leftangle_wt")]
        public string? cut_leftangle_wt { get; set; }
        // Angolo dx
        [XmlElement("cut_rightangle_wt")]
        public string? cut_rightangle_wt { get; set; }
        // Pezzo di pezzo
        // QUI TI DICE CHE PEZZO DI QUANTI PER ESEMPIO TI INDICA IL PRIMO SU 80
        [XmlElement("wt_piece_of_piece")]
        public string? wt_piece_of_piece { get; set; }
        [XmlElement("machinings")]
        public OperaMachiningsCreateModel? OperaMachinings { get; set; }
    }
}