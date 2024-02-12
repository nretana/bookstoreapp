using BookStore.API.DataTransfers;
using BookStore.API.DataTransfers.Response;
using BookStore.API.DataTransfers.Responses;
using BookStore.API.Entities.Account;
using BookStore.API.Models.Account.Request;

namespace BookStore.API.Services.Interfaces
{
    public interface IAccountService
    {
        Task<UserAccountResponse> GetUserAccountAsync(Guid userId);

        Task<SignUpResponse> SignUpAsync(SignUpRequestDto signUpRequest);

        Task<EmailConfirmationResponse> EmailConfirmationAsync(EmailConfirmationRequestDto confirmEmailRequest);

        Task<SignInResponse> SignInAsync(SignInRequestDto signInRequest);

        Task<TwoStepCodeResponse> SendTwoStepCodeAsync(TwoStepCodeRequestDto twoStepCodeRequest);

        Task<SignInResponse> ValidateTwoStepCodeAsync(TwoStepCodeValidationRequestDto twoStepCodeValidationRequest);

        Task<EmailConfirmationCodeResponse> SendEmailConfirmationCodeAsync(EmailConfirmationCodeRequestDto emailConfirmationCodeRequest);

        Task<SignUpResponse> ValidateEmailConfirmationCodeAsync(EmailConfirmationCodeValidationRequestDto emailConfirmationCodeValidationRequest);

        Task<PasswordResetCodeResponse> SendPasswordResetCodeAsync(PasswordResetCodeRequestDto passwordResetCodeRequestDto);

        Task<PasswordResetResponse> PasswordResetAsync(PasswordResetRequestDto passwordResetRequestDto);

        Task<bool> IsUserExistsAsync(string email);
    }
}
