using Microsoft.AspNetCore.Identity;

namespace WebPharmacy.Areas.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string? Name { get; set; }
    }
}
