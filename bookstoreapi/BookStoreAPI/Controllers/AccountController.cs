using AutoMapper;
using BookStore.API.DataTransfers;
using BookStore.API.DataTransfers.Responses;
using BookStore.API.Entities.Account;
using BookStore.API.Models.Account.Request;
using BookStore.API.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("api/accounts/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountRepository)
        {
            _accountService = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        [HttpGet("{userId}", Name = "GetUserAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserAccount(Guid userId)
        {
            var userAccountResponse = await _accountService.GetUserAccountAsync(userId);
            if (!userAccountResponse.IsSucceeded)
            {
                return NotFound();
            }

            return Ok(userAccountResponse);
        }

        [HttpPost(Name = "SignUp")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpRequestDto signUpRequest)
        {
            var signUpResponse = await _accountService.SignUpAsync(signUpRequest);
            if (!signUpResponse.IsSucceeded) {
                return BadRequest(signUpResponse);
            }

            return CreatedAtRoute("GetUserAccount", new { userId = signUpResponse.Data.Id }, signUpResponse);
        }

        [HttpPost(Name = "EmailConfirmation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EmailConfirmation(EmailConfirmationRequestDto confirmEmailRequest)
        {
            var confirmEmailResponse = await _accountService.EmailConfirmationAsync(confirmEmailRequest);
            if (!confirmEmailResponse.IsSucceeded)
            {
                return BadRequest(confirmEmailResponse);
            }

            return Ok(confirmEmailResponse);
        }

        [HttpPost(Name = "SignIn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> SignIn(SignInRequestDto signInRequest)
        {
            var signInResponse = await _accountService.SignInAsync(signInRequest);
            if (!signInResponse.IsSucceeded)
            {
                return Unauthorized(signInResponse);
            }

            return Ok(signInResponse);
        }

        [HttpPost(Name = "SendTwoStepCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendTwoStepCode(TwoStepCodeRequestDto twoStepCodeRequest)
        {
            var getTwoStepCodeResponse = await _accountService.SendTwoStepCodeAsync(twoStepCodeRequest);
            if (!getTwoStepCodeResponse.IsSucceeded)
            {
                return BadRequest(getTwoStepCodeResponse);
            }

            return Ok(getTwoStepCodeResponse);
        }

        [HttpPost(Name = "ValidTwoStepCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ValidateTwoStepCode(TwoStepCodeValidationRequestDto twoStepCodeValidationRequest)
        {
            var signInTwoStepResponse = await _accountService.ValidateTwoStepCodeAsync(twoStepCodeValidationRequest);
            if (!signInTwoStepResponse.IsSucceeded)
            {
                return BadRequest(signInTwoStepResponse);
            }

            return Ok(signInTwoStepResponse);
        }

        [HttpPost(Name = "SendEmailConfirmationCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendEmailConfirmationCode(EmailConfirmationCodeRequestDto emailConfirmationCodeRequest)
        {
            var emailConfirmationResponse =  await _accountService.SendEmailConfirmationCodeAsync(emailConfirmationCodeRequest);
            if (!emailConfirmationResponse.IsSucceeded)
            {
                return BadRequest(emailConfirmationResponse);
            }
            return Ok(emailConfirmationResponse);
        }

        [HttpPost(Name = "ValidateEmailConfirmationCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ValidateEmailConfirmationCode(EmailConfirmationCodeValidationRequestDto emailConfirmationCodeValidationRequest)
        {
            var emailConfirmationResponse = await _accountService.ValidateEmailConfirmationCodeAsync(emailConfirmationCodeValidationRequest);
            if (!emailConfirmationResponse.IsSucceeded)
            {
                return BadRequest(emailConfirmationResponse);
            }
            return Ok(emailConfirmationResponse);
        }

        [HttpPost(Name = "SendPasswordResetCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendPasswordResetCode(PasswordResetCodeRequestDto passwordResetCodeRequestDto)
        {
            var passwordResetResponse = await _accountService.SendPasswordResetCodeAsync(passwordResetCodeRequestDto);
            if (!passwordResetResponse.IsSucceeded)
            {
                return BadRequest(passwordResetResponse);
            }
            return Ok(passwordResetResponse);
        }

        [HttpPost(Name = "PasswordReset")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PasswordReset(PasswordResetRequestDto resetPasswordRequestDto)
        {
            var passwordResetResponse = await _accountService.PasswordResetAsync(resetPasswordRequestDto);
            if (!passwordResetResponse.IsSucceeded)
            {
                return BadRequest(passwordResetResponse);
            }
            return Ok(passwordResetResponse);
        }

        [HttpOptions]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAccountOptions()
        {
            Response.Headers.Add("Allow", "GET, HEAD, POST, OPTIONS");
            return Ok();
        }
    }
}
