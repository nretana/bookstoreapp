﻿using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Models.Account.Request
{
    public class PasswordResetCodeRequestDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;
    }
}
