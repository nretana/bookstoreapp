namespace BookStore.API.Models.Account.Response
{
    public class TwoStepCodeResponseDto
    {
        public string Email { get; set; } = string.Empty;

        public bool IsRememberMe { get; set; }

        public bool IsTwoStepEnabled { get; set; }

        //public string VerificationCode { get; set; }
    }
}
