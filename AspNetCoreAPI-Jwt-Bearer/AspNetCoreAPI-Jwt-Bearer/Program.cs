using AspNetCoreAPI_Jwt_Bearer.Data;
using AspNetCoreAPI_Jwt_Bearer.Interfaces;
using AspNetCoreAPI_Jwt_Bearer.Mapping;
using AspNetCoreAPI_Jwt_Bearer.Repositories;
using AspNetCoreAPI_Jwt_Bearer.Services;
using AspNetCoreAPI_Jwt_Bearer.StartExtensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<PersonelDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddJwtSettings(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();	//Kimlik Doðrulama ara katmaný (middleware)
app.UseAuthorization();    //Yetkilendirme ara katmaný (middleware)

app.MapControllers();

app.Run();
