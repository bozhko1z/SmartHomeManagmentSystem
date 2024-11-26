using Microsoft.AspNetCore.Identity;

namespace SmartHome.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
        }

        public virtual ICollection<UserDevice> UserDevices { get; set; } = new HashSet<UserDevice>();
    }
}
