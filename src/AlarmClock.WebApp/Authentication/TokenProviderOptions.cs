using System;
using Microsoft.IdentityModel.Tokens;

namespace AlarmClock.WebApp.Authentication
{
    public class TokenProviderOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public TimeSpan Expiration { get; set; } = TimeSpan.FromDays(1);

        public SigningCredentials SigningCredentials { get; set; }
    }
}
