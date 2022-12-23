using ECommerce.Core.Interfaces;
using ECommerce.Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerce.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }



        public async ValueTask<string> ValidateCredential(SignInViewModel signInVM)
        {
            var user = await _userManager.FindByEmailAsync(signInVM.Email);
            var result = await _signInManager.CheckPasswordSignInAsync(user, signInVM.Password, true);
            if (!result.Succeeded)
                return result.ToString();
            var claims = new List<Claim>
                           {
                               new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                               new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                               new Claim(JwtRegisteredClaimNames.NameId, user.Id),
                           };

            return GetToken(claims, _configuration["SigningKey"]);
        }

        public async ValueTask<string> CreateUser(SignUpViewModel signUpVM)
        {
            IdentityUser user = new IdentityUser
            {
                Email = signUpVM.Email,
                NormalizedEmail = signUpVM.Email.Normalize(),
                UserName = signUpVM.UserName,
                NormalizedUserName = signUpVM.UserName.Normalize()
            };
            var result = await _userManager.CreateAsync(user, signUpVM.Password);
            return result.Succeeded ? "Successfully Created User" : result.Errors.First().Description;
        }

        private string GetToken(List<Claim> authClaims, string secret)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(24),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async ValueTask<string> UpdateUser(SignUpViewModel signUp)
        {
            IdentityUser user = new IdentityUser
            {
                Email = signUp.Email,
                NormalizedEmail = signUp.Email.Normalize(),
                PasswordHash = signUp.Password,
                UserName = signUp.UserName,
                NormalizedUserName = signUp.UserName.Normalize()
            };
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded ? "Successfully Updated User" : result.Errors.First().Description;
        }
    }
}
