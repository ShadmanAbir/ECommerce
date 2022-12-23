using ECommerce.Core.Helpers;
using ECommerce.Core.Services;
using ECommerce.Domain.Models;
using ECommerce.Domain.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddDbContext<ECommerceContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceContext")));
builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<ECommerceContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthenticationCore();

builder.Services.AddSingleton<UnitOfWork>();
builder.Services.AddTransient<UserService>();
builder.Services.AddAutoMapper(typeof(MapperProfile));


// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
