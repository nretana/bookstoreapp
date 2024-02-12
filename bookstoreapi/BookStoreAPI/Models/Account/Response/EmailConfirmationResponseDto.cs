namespace BookStore.API.Models.Account.Response
{
    public class EmailConfirmationResponseDto
    {
        public string UserName { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
    }
}
