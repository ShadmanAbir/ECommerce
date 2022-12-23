using ECommerce.Core.Helpers;
using ECommerce.Core.Interfaces;
using ECommerce.Core.Services;
using ECommerce.Domain.Models;
using ECommerce.Domain.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddDbContext<ECommerceContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceContext")));
builder.Services.AddIdentityCore<IdentityUser>()
    .AddEntityFrameworkStores<ECommerceContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthenticationCore();

builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddTransient<IAuthService,AuthService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IMessageService, MessageService>();
builder.Services.AddTransient<ITagService, TagService>();
builder.Services.AddTransient<ISellPostService, SellPostService>();
builder.Services.AddTransient<ISellPostWiseTagService, SellPostWiseTagService>();
//builder.Services.AddTransient<IBlockListService, BockLis>();
builder.Services.AddScoped<SignInManager<IdentityUser>>();
builder.Services.AddScoped<UserManager<IdentityUser>>();
builder.Services.AddTransient<IHttpContextAccessor,HttpContextAccessor>();
//builder.Services.AddScoped<IConfiguration>();
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        corsPolicyBuilder =>
        {
            corsPolicyBuilder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

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
