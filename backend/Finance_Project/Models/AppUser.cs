using Microsoft.AspNetCore.Identity;

namespace Finance_Project.Models
{
    public class AppUser:IdentityUser
    {
        public List<Portfolio> Portfoilos { get; set; } = new List<Portfolio>();
    }
}
