namespace SteelProdBE.Models.Xml
{
    public class ModuleFileList
    {
        public string? Name { get; set; }
        public string? Dx { get; set; }
        public string? Da { get; set; } = "0";
        public string NRip { get; set; } = "0";
        public string DxRip { get; set; } = "0";
        public double Cut_length_external { get; set; }
        public string? CutIdCode { get; set; }
        public int CutIdCodeLenght { get; set; }
        public string? CutNameStart { get; set; } // nome nell loop cut id code
        public string? CutNameEnd { get; set; } // nome nell loop cut id code
        public string? Customer { get; set; }
        public string? MatName { get; set; }
        public string? MatColor { get; set; }
        public string? Model { get; set; }


        public bool LoopCutIdCode { get; set; }
        public string? DeltaX { get; set; }
        public string AvanzamentoDeltaX { get; set; }
    }
}
