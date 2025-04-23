using SteelProdBE.Entities.Typologies;
using SteelProdBE.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SteelProdBE.Models.ModuleXmlModels
{
    public class ModuleXmlUpdateModel
    {
        public int Id { get; set; }
        public string? Customer { get; set; }
        public string? MaterialName { get; set; }
        public string? NameXmlOpera { get; set; }
        public string? Name { get; set; }
        public string Dx { get; set; } = "0";
        public string Da { get; set; } = "0";
        public string NRip { get; set; } = "0";
        public string DxRip { get; set; } = "0";
        public bool RoundDx { get; set; } = false;
        public bool CeilDx { get; set; } = false;
        public bool RoundDa { get; set; } = false;
        public bool CeilDa { get; set; } = false;
        public bool RoundNRip { get; set; } = false;
        public bool CeilNRip { get; set; } = false;
        public bool RoundDxRip { get; set; } = false;
        public bool CeilDxRip { get; set; } = false;
        public string? DeltaX { get; set; }
        public string? AvanzamentoDeltaX { get; set; }
        public bool LoopCutIdCode { get; set; }
        public bool ByCustomer { get; set; }
        public bool ByMaterial { get; set; }
        public string? CutNameStart { get; set; }
        public string? CutNameEnd { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public bool ByRange { get; set; }
        public string? MaterialColor { get; set; }
        public bool ByMaterialColor { get; set; }
        public string? Model { get; set; }
        public bool ByModel { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
