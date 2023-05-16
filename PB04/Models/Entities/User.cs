using Microsoft.AspNetCore.Identity;

namespace PB04.Models.Entities
{
    public class User : IdentityUser<int>
    {
        public virtual IList<LeapYearCheck> Checks { get; set; }
    }
}
