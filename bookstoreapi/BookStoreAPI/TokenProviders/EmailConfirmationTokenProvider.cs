using Microsoft.AspNetCore.Identity;

namespace BookStore.API.TokenProviders
{
    public class EmailConfirmationTokenProvider<TUser> : TotpSecurityStampBasedTokenProvider<TUser> where TUser : class
    {
        public override Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<TUser> manager, TUser user)
        {
            return Task.FromResult(false);
        }
    }
}
