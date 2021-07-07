using HotelListing.Data;
using HotelListing.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Services.JWT
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;
        private ApiUser _user;

        public AuthManager(UserManager<ApiUser> userManager, 
            IConfiguration configuration, 
            ApiUser user)
        {
            _userManager = userManager;
            _configuration = configuration;
            _user = user;
        }

        public async Task<string> CreateToken()
        {
           
            //Get SigningCredentials
            SigningCredentials signingCredentials = GetSigningCredentials();
            //Get Claims/Roles
            List<Claim> claims = await GetClaimsAsync();
            //setup JwtSecurityToken

            string token = GenerateJwtToken(signingCredentials, claims);
            //Generate and Serialize token

            return token;
        }

        private string GenerateJwtToken(SigningCredentials SigningCredentials, 
            List<Claim> claims)
        {

            string Issuer = _configuration.GetSection("JwtSettings")
                .GetSection("Issuer").Value;
            string tokenLifeTime = _configuration.GetSection("JwtSettings")
                .GetSection("TokenLifeTime").Value;

            DateTime expiration = DateTime.Now.AddMinutes( Convert.ToDouble(tokenLifeTime));

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: Issuer,
                claims: claims,
                expires: expiration,
                signingCredentials: SigningCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        private SigningCredentials GetSigningCredentials()
        {
            string jwtKey = _configuration.GetSection("JwtSettings")
               .GetSection("SecretKey").Value;
            return new SigningCredentials(
               new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
               SecurityAlgorithms.HmacSha256
               );
        }

        private async Task<List<Claim>> GetClaimsAsync()
        {
            List<Claim> claims = new List<Claim>
           {
               new Claim (ClaimTypes.Name, _user.UserName)
           };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        public async Task<bool> ValidateUser(LoginDTO userDetails)
        {
            _user = await _userManager.FindByEmailAsync(userDetails.Email);
           bool isPasswordValid = await _userManager.CheckPasswordAsync(_user, userDetails.Password);

           return (_user != null && isPasswordValid) ? true : false;
        
        }

    }
}
