using ApiFirst.Services.Classes;
using AspRolesRazor.Areas.Identity.Data;
using AspRolesRazor.Areas.Identity.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AspRolesRazor.Data;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string 'UsersContextConnection' not found.");

builder.Services.AddDbContext<UsersContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<UsersContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();

builder.Services.AddAuthorization(ops =>
{
    ops.AddPolicy("RequireAdmin", pb => pb.RequireRole(AppRoles.AdminUser));
    ops.AddPolicy("RequireSuperAdmin", pb => pb.RequireRole(AppRoles.SuperAdminUser));
    ops.AddPolicy("RequireUser", pb => pb.RequireRole(AppRoles.AppUser));
});

builder.Services.AddSingleton<IEmailSender, EmailSender>();

builder.Services.AddRazorPages(ops =>
{
    ops.Conventions.AuthorizeFolder("/Admin", "RequireAdmin");
    ops.Conventions.AuthorizeFolder("/User", "RequireUser");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization(); 

app.MapRazorPages();

app.Run();