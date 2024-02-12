using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Models.Account.Request
{
    public class TwoStepCodeRequestDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        public bool IsRememberMe { get; set; }
    }
}
