using Microsoft.AspNetCore.Identity;

namespace Biible.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationRole //: IdentityRole
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NormalizedName { get; set; }
    }
}
