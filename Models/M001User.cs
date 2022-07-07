using Microsoft.AspNetCore.Identity;

namespace Agency.Models
{
    public class M001User:IdentityUser
    {
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
