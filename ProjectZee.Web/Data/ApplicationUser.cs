using Microsoft.AspNetCore.Identity;

namespace ProjectZee.Web.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public List<Project> FollowedProjects { get; set; }
    }


}
