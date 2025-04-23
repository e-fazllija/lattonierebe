using SteelProdBE.Entities.Xml;
using SteelProdBE.Models.Xml.XmlCreateModels;
using SteelProdBE.Models.Xml.XmlSelectModels;
using SteelProdBE.Models.Xml.XmlUpdateModels;

namespace SteelProdBE.Profiles.XmlProfiles
{
    public class OperaJobCustomerProfile : AutoMapper.Profile
    {
        public OperaJobCustomerProfile()
        {
            CreateMap<OperaJobCustomer, OperaJobCustomerCreateModel>();
            CreateMap<OperaJobCustomer, OperaJobCustomerUpdateModel>();
            CreateMap<OperaJobCustomer, OperaJobCustomerSelectModel>();
            CreateMap<OperaJobCustomerSelectModel, OperaJobCustomerUpdateModel>();
            CreateMap<OperaJobCustomerUpdateModel, OperaJobCustomerSelectModel>();

            CreateMap<OperaJobCustomerCreateModel, OperaJobCustomer>();
            CreateMap<OperaJobCustomerUpdateModel, OperaJobCustomer>();
            CreateMap<OperaJobCustomerSelectModel, OperaJobCustomer>();

        }
    }
}
