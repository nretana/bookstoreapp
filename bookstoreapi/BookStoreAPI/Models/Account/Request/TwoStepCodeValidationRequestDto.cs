﻿using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Models.Account.Request
{
    public class TwoStepCodeValidationRequestDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string VerificationCode { get; set; } = string.Empty;

        public bool IsRememberMe { get; set; }
    }
}
