using Microsoft.AspNetCore.Identity;

namespace BookStore.API.Entities.Account
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;
    }
}
