using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Models.Account.Request
{
    public class SignInRequestDto
    {
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        public bool IsRememberMe { get; set; }
    }
}
