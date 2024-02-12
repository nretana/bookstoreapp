using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Models.Account.Request
{
    public class SignUpRequestDto
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = string.Empty;

        /*[DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email verification url is required to continue the process")]
        public string EmailVerificationUrl { get; set; }*/

    }
}
