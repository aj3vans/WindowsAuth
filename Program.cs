using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authorization;
using WindowsAuth;
using WindowsAuth.Authorization;
using WindowsAuth.Connections;
using WindowsAuth.Interfaces;
using WindowsAuth.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUserRepository, UserRepositiory>();
builder.Services.AddScoped<IUserPermissionRepository, UserPermissionRepository>();
builder.Services.AddScoped<ISqlConn, SqlConn>();

// Configure claims-based authentication for windows
// ------------------------------------------------------------------------
// ------------------------------------------------------------------------

// Configure authentication (for windows)
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

// Configure authorization options (for roles and claims)
builder.Services.AddAuthorization(options => {

    // Add required roles
    options.AddPolicy("IsAdmin", options => options.RequireRole("Admin"));
    options.AddPolicy("IsBasic", options => options.RequireRole("Basic"));
    
    // Add required claims 
    options.AddPolicy("CanEditUsers", options => options.RequireClaim("Permission", "User.Edit"));
    options.AddPolicy("IsAccountOwner", options => options.AddRequirements(new IsAccountOwnerRequirement()));
    options.AddPolicy("IsOlderThan", options => options.AddRequirements(new MustBeOlderThanRequirement(38)));
});

// Add custom authorization handlers
builder.Services.AddSingleton<IAuthorizationHandler, IsAccountOwnerAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, MustBeOlderThanAuthorizationHandler>();


// Add custom claims to the windows authenticated user 
builder.Services.AddScoped<IClaimsTransformation, ClaimsTransformer>();
// ------------------------------------------------------------------------
// ------------------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/User/Error");
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
    pattern: "{controller=User}/{action=Manage}/{userid?}");

app.Run();
