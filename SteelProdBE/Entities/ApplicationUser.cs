using Microsoft.AspNetCore.Identity;

namespace SteelProdBE.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
