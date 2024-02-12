using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Models.Account.Request
{
    public class PasswordResetRequestDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string NewPassword { get; set; } = string.Empty;   

        [Required]
        public string VerificationCode { get; set; } = string.Empty;
    }
}
