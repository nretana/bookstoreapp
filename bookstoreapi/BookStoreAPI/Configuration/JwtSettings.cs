﻿using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Runtime.InteropServices;

namespace BookStore.API.Configuration
{
    public class JwtSettings
    {
        public string SecurityKey { get; set; } = string.Empty;
        
        public string ValidIssuer { get; set; } = string.Empty;

        public string ValidAudience { get; set;} = string.Empty;

        public int ExpiryInMinutes { get; set; }

    }
}
