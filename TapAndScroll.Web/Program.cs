using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TapAndScroll.Application.HelperContracts;
using TapAndScroll.Application.RepositoryContracts;
using TapAndScroll.Application.ServiceContracts;
using TapAndScroll.Core;
using TapAndScroll.Core.Models;
using TapAndScroll.Infrastructure.Helpers;
using TapAndScroll.Infrastructure.Repositories;
using TapAndScroll.Infrastructure.Services;
using TapAndScroll.Web.Middleware;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TapAndScrollDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("TapAndScroll.Web")),
        ServiceLifetime.Scoped);

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductImgRepository, ProductImageRepository>();
builder.Services.AddScoped<IAdditionalParametersCategoryRepository, AdditionalParametersCategoryRepository>();
builder.Services.AddScoped<IAdditionalParametersRepository, AdditionalParametersRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAuthorizeService, AuthorizeService>();
builder.Services.AddScoped<IEmailService, EmailFakeService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IImageProductService, ImageProductService>();
builder.Services.AddScoped<ICatalogService, CatalogService>();
builder.Services.AddScoped<IConfirmHelper, ConfirmHelper>();
builder.Services.AddScoped<IParametersHelper, ParametersHelper>();
builder.Services.AddScoped<IJwtHelper, JwtHelper>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:SecretKey"])),
            ValidIssuer = builder.Configuration["JwtOptions:Issuer"]
        };

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["tasty-cookies"];

                return Task.CompletedTask;
            },

            OnChallenge = context =>
            {
                context.HandleResponse();
                context.Response.Redirect("/Authorize/Login");
                return Task.CompletedTask;
            },
        };

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseRedirectUnauthorized();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
