using Microsoft.AspNetCore.Identity;

namespace tech_shop.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
