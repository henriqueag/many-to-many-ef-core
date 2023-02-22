using Identity.CustomPolicy;
using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();
builder.Services.Configure<DataProtectionTokenProviderOptions>(opts => opts.TokenLifespan = TimeSpan.FromHours(10));

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = ".AspNetCore.Identity.Application";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    options.SlidingExpiration = true;
});

builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy("AspManager", policy =>
    {
        policy.RequireRole("Manager");
        policy.RequireClaim("Coding-Skill", "ASP.NET Core MVC");
    });
});

builder.Services.AddTransient<IAuthorizationHandler, AllowUsersHandler>();
builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy("AllowTom", policy =>
    {
        policy.AddRequirements(new AllowUserPolicy("tom"));
    });
});

builder.Services.AddTransient<IAuthorizationHandler, AllowPrivateHandler>();
builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy("PrivateAccess", policy =>
    {
        policy.AddRequirements(new AllowPrivatePolicy());
    });
});

builder.Services.AddAuthentication()
        .AddGoogle(options =>
        {
            options.ClientId = "900631683747-95s0l14sp6ul945bgi380t128mhpuqk6.apps.googleusercontent.com";
            options.ClientSecret = "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";
            options.SignInScheme = IdentityConstants.ExternalScheme;
        });

builder.Services.Configure<IdentityOptions>(opts =>
{
    opts.Lockout.AllowedForNewUsers = true;
    opts.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    opts.Lockout.MaxFailedAccessAttempts = 3;
});

/*builder.Services.Configure<IdentityOptions>(opts =>
{
    opts.SignIn.RequireConfirmedEmail = true;
});*/

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
