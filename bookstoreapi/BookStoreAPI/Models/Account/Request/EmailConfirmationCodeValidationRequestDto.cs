using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Models.Account.Request
{
    public class EmailConfirmationCodeValidationRequestDto
    {
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string VerificationCode { get; set; } = null!;
    }
}
