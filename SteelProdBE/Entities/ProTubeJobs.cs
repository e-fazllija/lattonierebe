namespace SteelProdBE.Entities
{
    public class ProTubeJobs: EntityBase
    {
        public int XmlId { get; set; }
        public int ProTubeJobId { get; set; }
        public string? JobName { get; set; }
        public int? JobBarNum { get; set; }
        public double? JobBarTotLen { get; set; }
        public long? JobEstProdTime { get; set; }
        public int? JobScrapPerc { get; set; }
        public int? JobPartNumPlaced { get; set; }
        public int? JobNestPercPartPlacing { get; set; }
        public bool JobTransferred { get; set; }
        public bool Nesting { get; set; }
        public string? TransferError { get; set; }
        public bool ProfilesQuantityUpdated { get; set; }
    }
}
