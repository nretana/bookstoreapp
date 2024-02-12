using AutoMapper;
using Azure.Core;
using BookStore.API.DataTransfers;
using BookStore.API.DataTransfers.Response;
using BookStore.API.DataTransfers.Responses;
using BookStore.API.Entities.Account;
using BookStore.API.Models.Account.Request;
using BookStore.API.Models.Account.Response;
using BookStore.API.Services.Interfaces;
using EmailService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace BookStore.API.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;

        private List<Error> ValidationErrors { get; set; } = new List<Error>();

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager,
                                    IEmailSender emailSender, IMapper mapper, IJwtService jwtService)
        {

            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _emailSender = emailSender ?? throw new ArgumentNullException(nameof(emailSender));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));
        }

        public async Task<UserAccountResponse> GetUserAccountAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                ValidationErrors.Add(new Error { Code = "SIGNUP_ERROR", Description = "Username not found." });
                return new UserAccountResponse()
                {
                    IsSucceeded = false,
                    Errors = ValidationErrors
                };
            }

            var userAccountData = _mapper.Map<UserAccountResponseDto>(user);

            return new UserAccountResponse()
            {
                Data = userAccountData,
                IsSucceeded = true
            };
        }

        public async Task<SignUpResponse> SignUpAsync(SignUpRequestDto signUpRequest)
        {
            var user = _mapper.Map<User>(signUpRequest);
            var signUpResponse = await _userManager.CreateAsync(user, signUpRequest.Password);
            if (!signUpResponse.Succeeded)
            {
                GenerateErrors(signUpResponse);
                return new SignUpResponse
                {
                    IsSucceeded = false,
                    Errors = ValidationErrors
                };
            }

            await _userManager.AddToRoleAsync(user, "Visitor");

            var userRegistered = await _userManager.FindByEmailAsync(user.Email);
            if (userRegistered == null)
            {
                ValidationErrors.Add(new Error { Code = "SIGNUP_ERROR", Description = "Username not found." });
                return new SignUpResponse()
                {
                    IsSucceeded = false,
                    Errors = ValidationErrors
                };
            }

            return new SignUpResponse()
            {
                IsSucceeded = true,
                Data = new SignUpResponseDto()
                {
                    Id = new Guid(userRegistered.Id),
                    UserName = user.Email ?? string.Empty,
                    FirstName = user.FirstName ?? string.Empty,
                    LastName = user.LastName ?? string.Empty
                }
            };
        }

        public async Task<EmailConfirmationResponse> EmailConfirmationAsync(EmailConfirmationRequestDto confirmEmailRequest)
        {
            if (string.IsNullOrEmpty(confirmEmailRequest.Email))
            {
                ValidationErrors.Add(new Error { Code = "INVALID_EMAIL", Description = "Invalid email." });
                return new EmailConfirmationResponse()
                {
                    IsSucceeded = false,
                    Errors = ValidationErrors
                };
            }

            if (string.IsNullOrEmpty(confirmEmailRequest.Token))
            {
                ValidationErrors.Add(new Error { Code = "INVALID_TOKEN", Description = "Invalid token." });
                return new EmailConfirmationResponse()
                {
                    IsSucceeded = false,
                    Errors = ValidationErrors
                };
            }

            var user = await _userManager.FindByEmailAsync(confirmEmailRequest.Email);
            if (user == null)
            {
                ValidationErrors.Add(new Error { Code = "INVALID_USER", Description = "Invalid username." });
                return new EmailConfirmationResponse()
                {
                    IsSucceeded = false,
                    Errors = ValidationErrors
                };
            }

            var emailConfirmationResponse = await _userManager.ConfirmEmailAsync(user, confirmEmailRequest.Token);
            if (!emailConfirmationResponse.Succeeded)
            {
                GenerateErrors(emailConfirmationResponse);
                return new EmailConfirmationResponse()
                {
                    IsSucceeded = false,
                    Errors = ValidationErrors
                };
            }

            return new EmailConfirmationResponse()
            {
                Data = new EmailConfirmationResponseDto()
                {
                    UserName = user.Email ?? string.Empty,
                    FirstName = user.FirstName ?? string.Empty,
                    LastName = user.LastName ?? string.Empty
                },
                IsSucceeded = true
            };
        }

        public async Task<SignInResponse> SignInAsync(SignInRequestDto signInRequest)
        {
            var user = await _userManager.FindByEmailAsync(signInRequest.Email);
            if (user == null)
            {
                ValidationErrors.Add(new Error { Code = "INVALID_USER", Description = "Invalid username or password." });
                return new SignInResponse()
                {
                    IsSucceeded = false,
                    Errors = ValidationErrors
                };
            }

            var isEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
            if (!isEmailConfirmed)
            {
                ValidationErrors.Add(new Error { Code = "EMAIL_NOT_CONFIRMED", Description = "Email has not been confirmed." });
                return new SignInResponse()
                {
                    Data = new SignInResponseDto() { IsEmailConfirmed = false },
                    IsSucceeded = false,
                    Errors = ValidationErrors
                };
            }

            var signInResult = await _signInManager.PasswordSignInAsync(signInRequest.Email, signInRequest.Password,
                                                            signInRequest.IsRememberMe, true);
            if (signInResult.IsLockedOut)
            {
                ValidationErrors.Add(new Error { Code = "USER_LOCKOUT", Description = "User is lockout." });
                return new SignInResponse()
                {
                    Data = new SignInResponseDto() { IsLockedOut = true },
                    IsSucceeded = false,
                    Errors = ValidationErrors
                };
            }

            if (!signInResult.Succeeded && !signInResult.RequiresTwoFactor)
            {
                ValidationErrors.Add(new Error { Code = "INVALID_USER", Description = "Invalid username or password." });
                return new SignInResponse()
                {
                    IsSucceeded = false,
                    Errors = ValidationErrors
                };
            }

            if(signInResult.RequiresTwoFactor)
            {
                return new SignInResponse()
                {
                    Data = new SignInResponseDto()
                    {
                        Id = new Guid(user.Id),
                        UserName = user.UserName!,
                        Email = user.UserName!,
                        IsRememberMe = signInRequest.IsRememberMe,
                        IsEmailConfirmed = user.EmailConfirmed,
                        IsTwoStepEnabled = true,
                        IsLockedOut = false,
                    },
                    IsSucceeded = true
                };
            }

            var signingCredentials = _jwtService.GetSigningCredentials();
            var claims = _jwtService.GetClaims(user);
            var tokenOptions = _jwtService.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new SignInResponse()
            {
                Data = new SignInResponseDto()
                {
                    Id = new Guid(user.Id),
                    UserName = user.UserName!,
                    Email = user.Email!,
                    IsRememberMe = signInRequest.IsRememberMe,
                    Token = token,
                    IsEmailConfirmed = user.EmailConfirmed,
                    IsTwoStepEnabled = false,
                    IsLockedOut = false
                },
                IsSucceeded = true,
            };
        }

        public async Task<TwoStepCodeResponse> SendTwoStepCodeAsync(TwoStepCodeRequestDto twoStepCodeRequest)
        {
            var user = await _userManager.FindByNameAsync(twoStepCodeRequest.Email);
            if (user == null)
            {
                ValidationErrors.Add(new Error { Code = "INVALID_USER", Description = "Invalid username or password." });
                return new TwoStepCodeResponse()
                {
                    IsSucceeded = false,
                    Errors = ValidationErrors
                };
            }

            var tokenProviders = await _userManager.GetValidTwoFactorProvidersAsync(user);
            if (!tokenProviders.Contains("Email"))
            {
                ValidationErrors.Add(new Error { Code = "INVALID_TOKEN_PROVIDER", Description = "Invalid token provider." });
                return new TwoStepCodeResponse()
                {
                    IsSucceeded = false,
                    Errors = ValidationErrors
                };
            }

            var userTokenCode = await GenerateTwoStepCodeAsync(user, "Email");

            return new TwoStepCodeResponse()
            {
                Data = new TwoStepCodeResponseDto()
                {
                    Email = user.Email ?? string.Empty,
                    IsRememberMe = twoStepCodeRequest.IsRememberMe,
                    IsTwoStepEnabled = true
                },
                IsSucceeded = true
            };
        }

        public async Task<SignInResponse> ValidateTwoStepCodeAsync(TwoStepCodeValidationRequestDto twoStepCodeValidationRequest)
        {
            var user = await _userManager.FindByNameAsync(twoStepCodeValidationRequest.Email);
            if (user == null)
            {
                ValidationErrors.Add(new Error { Code = "INVALID_USER", Description = "Invalid username or password." });
                return new SignInResponse()
                {
                    IsSucceeded = false,
                    Errors = ValidationErrors
                };
            }

            var isCanSignIn = await _signInManager.CanSignInAsync(user);
            var isLockedOut = _signInManager.UserManager.SupportsUserLockout
                                    && await _signInManager.UserManager.IsLockedOutAsync(user);

            if (!isCanSignIn || isLockedOut)
            {
                ValidationErrors.Add(new Error { Code = "USER_LOCKOUT", Description = "User is lockout." });
                return new SignInResponse()
                {
                    IsSucceeded = false,
                    Errors = ValidationErrors
                };
            }

            var isValidTwoFactorCode = await _userManager.VerifyTwoFactorTokenAsync(user, "Email", twoStepCodeValidationRequest.VerificationCode);
            if (!isValidTwoFactorCode)
            {
                // If the token is incorrect, record the failure which also may cause the user to be locked out
                if (_signInManager.UserManager.SupportsUserLockout)
                {
                    await _signInManager.UserManager.AccessFailedAsync(user);
                }

                var error = new Error() { Code = "INVALID_CODE", Description = "Invalid code." };
                if (await _signInManager.UserManager.IsLockedOutAsync(user))
                {
                    error.Code = "USER_LOCKOUT";
                    error.Description = "Your account has been locked out.";
                }

                ValidationErrors.Add(error);

                return new SignInResponse()
                {
                    IsSucceeded = false,
                    Errors = ValidationErrors
                };

            }

            var signingCredentials = _jwtService.GetSigningCredentials();
            var claims = _jwtService.GetClaims(user);
            var tokenOptions = _jwtService.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new SignInResponse()
            {
                Data = new SignInResponseDto()
                {
                    Id = new Guid(user.Id),
                    UserName = user.UserName ?? string.Empty,
                    Email = user.UserName ?? string.Empty,
                    Token = token,
                    IsRememberMe = twoStepCodeValidationRequest.IsRememberMe,
                    IsEmailConfirmed = user.EmailConfirmed,
                    IsLockedOut = false,
                    IsTwoStepEnabled = true
                },
                IsSucceeded = true
            };
        }

        public async Task<EmailConfirmationCodeResponse> SendEmailConfirmationCodeAsync(EmailConfirmationCodeRequestDto emailConfirmationCodeRequest)
        {
            var user = await _userManager.FindByEmailAsync(emailConfirmationCodeRequest.Email);
            if (user == null)
            {
                ValidationErrors.Add(new Error { Code = "INVALID_USER", Description = "Invalid username or password." });
                return new EmailConfirmationCodeResponse()
                {
                    IsSucceeded = false,
                    Errors = ValidationErrors
                };
            }

            var emailToken = await SendEmailVerificationAsync(user, "EmailConfirmation", "email-confirmation");

            return new EmailConfirmationCodeResponse()
            {
                Data = new EmailConfirmationCodeResponseDto()
                {
                    Email = user.Email ?? string.Empty,
                    IsEmailConfirmed = false
                },
                IsSucceeded = true,
            };
        }

        public async Task<SignUpResponse> ValidateEmailConfirmationCodeAsync(EmailConfirmationCodeValidationRequestDto emailConfirmationCodeValidationRequest)
        {
            var user = await _userManager.FindByEmailAsync(emailConfirmationCodeValidationRequest.Email);
            if (user == null)
            {
                ValidationErrors.Add(new Error { Code = "INVALID_USER", Description = "Invalid username or password." });
                return new SignUpResponse()
                {
                    IsSucceeded = false,
                    Errors = ValidationErrors
                };
            }

            var isValidEmailToken = await _userManager.VerifyUserTokenAsync(user, "EmailConfirmation",
                                                    "email-confirmation", emailConfirmationCodeValidationRequest.VerificationCode);

            if (!isValidEmailToken)
            {
                var error = new Error() { Code = "INVALID_CODE", Description = "Invalid code." };
                if (await _signInManager.UserManager.IsLockedOutAsync(user))
                {
                    error.Code = "USER_LOCKOUT";
                    error.Description = "Your account has been locked out.";
                }

                ValidationErrors.Add(error);

                return new SignUpResponse()
                {
                    IsSucceeded = false,
                    Errors = ValidationErrors
                };
            }

            user.EmailConfirmed = true;
            await _userManager.UpdateAsync(user);

            return new SignUpResponse()
            {
                Data = new SignUpResponseDto()
                {
                    Id = new Guid(user.Id),
                    UserName = user.UserName ?? string.Empty,
                    FirstName = user.FirstName ?? string.Empty,
                    LastName = user.LastName ?? string.Empty
                },
                IsSucceeded = true,
            };
        }

        public async Task<PasswordResetCodeResponse> SendPasswordResetCodeAsync(PasswordResetCodeRequestDto passwordResetCodeRequestDto)
        {
            if (string.IsNullOrEmpty(passwordResetCodeRequestDto.Email))
            {
                ValidationErrors.Add(new Error { Code = "INVALID_EMAIL", Description = "Invalid email." });
                return new PasswordResetCodeResponse()
                {
                    IsSucceeded = false,
                    Errors = ValidationErrors
                };
            }

            var user = await _userManager.FindByEmailAsync(passwordResetCodeRequestDto.Email);
            if (user == null)
            {
                ValidationErrors.Add(new Error { Code = "INVALID_USER", Description = "Invalid username." });
                return new PasswordResetCodeResponse()
                {
                    IsSucceeded = false,
                    Errors = ValidationErrors
                };
            }

            var emailToken = await SendPasswordResetAsync(user);
            return new PasswordResetCodeResponse()
            {
                Data = new PasswordResetCodeResponseDto()
                {
                    Email = user.Email ?? string.Empty
                },
                IsSucceeded = true
            };
        }

        public async Task<PasswordResetResponse> PasswordResetAsync(PasswordResetRequestDto passwordResetRequestDto)
        {
            if (string.IsNullOrEmpty(passwordResetRequestDto.Email))
            {
                ValidationErrors.Add(new Error { Code = "INVALID_EMAIL", Description = "Invalid email." });
                return new PasswordResetResponse()
                {
                    IsSucceeded = false,
                    Errors = ValidationErrors
                };
            }

            var user = await _userManager.FindByEmailAsync(passwordResetRequestDto.Email);
            if(user is null)
            {
                ValidationErrors.Add(new Error { Code = "INVALID_USER", Description = "Invalid username or password." });
                return new PasswordResetResponse()
                {
                    IsSucceeded = false,
                    Errors = ValidationErrors
                };
            }

            var resetPasswordResult = await _userManager.ResetPasswordAsync(user, passwordResetRequestDto.VerificationCode, passwordResetRequestDto.NewPassword);
            if(!resetPasswordResult.Succeeded) {
                var error = new Error() { Code = "INVALID_TOKEN", Description = "Invalid token." };
                ValidationErrors.Add(error);

                return new PasswordResetResponse()
                {
                    IsSucceeded = false,
                    Errors = ValidationErrors
                };
            }

            return new PasswordResetResponse()
            {
                Data = new PasswordResetResponseDto()
                {
                    Email = user?.Email ?? string.Empty
                },
                IsSucceeded = true
            };
        }

        public async Task<bool> IsUserExistsAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user != null;
        }

        private void GenerateErrors(IdentityResult identityResponse)
        {
            foreach (var error in identityResponse.Errors)
            {
                if (error.Code == "DuplicateUserName")
                {
                    ValidationErrors.Add(new Error { Code = "SIGNUP_USER", Description = "Username or password not allowed." });
                    continue;
                }

                if (error.Code == "InvalidToken")
                {
                    ValidationErrors.Add(new Error { Code = "INVALID_TOKEN", Description = "Your token has expired" });
                    continue;
                }

                ValidationErrors.Add(new Error { Code = error.Code, Description = error.Description });
            }
        }

        private async Task<string> SendEmailVerificationAsync(User user, string tokenProvider, string tokenPurpose)
        {
            var emailToken = await _userManager.GenerateUserTokenAsync(user, tokenProvider, tokenPurpose);

            Message mailMessage = new(new string[] { user.Email! }, "Email Verification", emailToken);

            await _emailSender.SendEmailAsync(mailMessage);

            return emailToken;
        }

        private async Task<string> SendPasswordResetAsync(User user)
        {
            var emailToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            Message mailMessage = new(new string[] { user.Email! }, "Password Reset", emailToken);

            await _emailSender.SendEmailAsync(mailMessage);

            return emailToken;
        }

        private async Task<string> GenerateTwoStepCodeAsync(User user, string tokenProvider)
        {
            var userTokenCode = await _userManager.GenerateTwoFactorTokenAsync(user, tokenProvider);

            Message message = new(new string[] { user.Email! }, "2-Step Verification", userTokenCode);
            await _emailSender.SendEmailAsync(message);

            return userTokenCode;
        }
    }
}
