namespace SteelProdBE.Models.XmlFileListModels
{
        public class XmlFileListCreateModel
        {
            public int id { get; set; }
            public string? job_id { get; set; }
            public string? job_name { get; set; }
            public string? customer { get; set; }
            public string? cmp_panes { get; set; }
            public List<XmlFileListMaterialCreateModel> materials { get; set; }
        }

        public class XmlFileListMaterialCreateModel
        {
            public string? mat_name { get; set; }
            public string? col_name { get; set; }
            public List<XmlFileListCutCreateModel> xmlCuts { get; set; }
        }

        public class XmlFileListCutCreateModel
        {
            public string? cut_lenght_external { get; set; }
            public string? cut_idcode { get; set; }
            public string? machiningsCheck { get; set; }
            public int quantity { get; set; } = 1;
            public List<XmlFileListMachiningsCreateModel> xmlMachinings { get; set; }
        }

        public class XmlFileListMachiningsCreateModel
        {
            public string? mach_name { get; set; }
        }
  
}
