using AspNetCoreAPI_Jwt_Bearer.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AspNetCoreAPI_Jwt_Bearer.Services
{
	public class AuthService : IAuthService
	{
		private readonly IConfiguration _configuration;
		public AuthService(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public string GenerateToken()
		{
			var jwtDefaults = _configuration.GetSection("JwtDefaults");
			var secretKey = jwtDefaults["secretKey"];

			SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

			SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			List<Claim> claims = new List<Claim>()
			{
				new Claim(ClaimTypes.Role, "Admin")
			};

			JwtSecurityToken token = new JwtSecurityToken(issuer: jwtDefaults["ValidIssuer"], audience: jwtDefaults["ValidAudience"], claims: claims, notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtDefaults["expires"])), signingCredentials: signingCredentials);

			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
			return handler.WriteToken(token);
		}
	}
}
