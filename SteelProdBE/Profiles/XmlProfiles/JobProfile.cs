using SteelProdBE.Entities.Xml;
using SteelProdBE.Models.Xml.XmlCreateModels;
using SteelProdBE.Models.Xml.XmlSelectModels;
using SteelProdBE.Models.Xml.XmlUpdateModels;

namespace SteelProdBE.Profiles.XmlProfiles
{
    public class JobProfile : AutoMapper.Profile
    {
        public JobProfile() 
        {
            CreateMap<Job, JobCreateModel>();
            CreateMap<Job, JobUpdateModel>();
            CreateMap<Job, JobSelectModel>();
            CreateMap<JobSelectModel, JobUpdateModel>();
            CreateMap<JobUpdateModel, JobSelectModel>();

            CreateMap<JobCreateModel, Job>();
            CreateMap<JobUpdateModel, Job>();
            CreateMap<JobSelectModel, Job>();
        }
    }
}
