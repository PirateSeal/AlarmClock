using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AlarmClock.WebApp.Authentication;
using Microsoft.Extensions.Options;

namespace AlarmClock.WebApp.Services
{
    public class TokenService
    {
        private readonly TokenProviderOptions _options;

        public TokenService( IOptions<TokenProviderOptions> options )
        {
            _options = options.Value;
        }

        public Token GenerateToken( string userId, string email )
        {
            DateTime now = DateTime.UtcNow;

            // Specifically add the iat (issued timestamp), and sub (subject/user) claims.
            // You can add other claims here, if you want:
            var claims = new[]
            {
                new Claim( JwtRegisteredClaimNames.Sub, userId ),
                new Claim( JwtRegisteredClaimNames.Email, email ),
                new Claim( JwtRegisteredClaimNames.Iat,
                    ((int) (now - new DateTime( 1970, 1, 1 )).TotalSeconds).ToString(), ClaimValueTypes.Integer64 )
            };

            // Create the JWT and write it to a string
            JwtSecurityToken jwt = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claims,
                now,
                now.Add( _options.Expiration ),
                _options.SigningCredentials );
            string encodedJwt = new JwtSecurityTokenHandler().WriteToken( jwt );

            return new Token( encodedJwt, (int) _options.Expiration.TotalSeconds );
        }
    }

    public class Token
    {
        public Token( string accessToken, int expiresIn )
        {
            AccessToken = accessToken;
            ExpiresIn = expiresIn;
        }

        public string AccessToken { get; }

        public int ExpiresIn { get; }
    }
}
