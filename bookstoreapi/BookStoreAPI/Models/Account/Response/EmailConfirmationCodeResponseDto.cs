namespace BookStore.API.Models.Account.Response
{
    public class EmailConfirmationCodeResponseDto
    {
        public string Email { get; set; } = string.Empty;

        public bool IsEmailConfirmed { get; set; }
    }
}
