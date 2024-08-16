using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AspNetCoreAPI_Jwt_Bearer.StartExtensions
{
	public static class JwtExtensions
	{
		public static void AddJwtSettings(this IServiceCollection services, IConfiguration configuration)
		{
			var jwtDefaults = configuration.GetSection("JwtDefaults");
			var secretKey = jwtDefaults["secretKey"];

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
			{
				opt.RequireHttpsMetadata = false;
				opt.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = jwtDefaults["ValidIssuer"],
					ValidAudience = jwtDefaults["ValidAudience"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
					ClockSkew = TimeSpan.Zero
				};
			});
		}
	}
}
