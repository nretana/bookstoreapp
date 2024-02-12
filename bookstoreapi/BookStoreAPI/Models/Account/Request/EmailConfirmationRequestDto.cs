using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Models.Account.Request
{
    public class EmailConfirmationRequestDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Token { get; set; } = string.Empty;
    }
}
