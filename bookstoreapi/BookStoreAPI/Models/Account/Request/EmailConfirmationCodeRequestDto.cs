using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Models.Account.Request
{
    public class EmailConfirmationCodeRequestDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;

    }
}
