namespace BookStore.API.Models.Account.Response
{
    public class SignUpResponseDto
    {
        public Guid Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string EmailToken { get; set; } = string.Empty;
    }
}
