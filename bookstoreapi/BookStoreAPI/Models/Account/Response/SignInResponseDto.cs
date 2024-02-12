namespace BookStore.API.Models.Account.Response
{
    public class SignInResponseDto
    {
        public Guid Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public bool IsRememberMe { get; set; }

        public string Token { get; set; } = string.Empty;

        public bool IsEmailConfirmed { get; set; }

        public bool IsLockedOut { get; set; }

        public bool IsTwoStepEnabled { get; set; }
    }
}
