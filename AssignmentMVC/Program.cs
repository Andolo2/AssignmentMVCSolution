using AssignmentMVC.Contexts;
using AssignmentMVC.Models.Identity;
using AssignmentMVC.Repositories;
using AssignmentMVC.Services.Authentication;
using AssignmentMVC.Services.ProductServices;
using AssignmentMVC.Services.ShowCaseServices;
using AssignmentMVC.Services.UpToSaleService;using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using static AssignmentMVC.Services.ShowCaseServices.ShowCaseService;



var builder = WebApplication.CreateBuilder(args);


// ADD DATACONTEXT START
builder.Services.AddDbContext<DataContexts>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ProductSql")));
builder.Services.AddDbContext<ContactContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ContactSql")));
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("UserSql")));





// REGISTER SERVICES START //
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ShowCaseServices>(); //Added for Dependency injecttion
builder.Services.AddScoped<UpToSaleService>(); //Added for Dependency injecttion
builder.Services.AddScoped<ProductService>();  //Added for Dependency injecttion
builder.Services.AddScoped<AddressRepository>();  //Added for Dependency injecttion
builder.Services.AddScoped<UserAddressRepository>();  //Added for Dependency injecttion
builder.Services.AddScoped<AddressService>();  //Added for Dependency injecttion
builder.Services.AddScoped<AuthenticationService>();  //Added for Dependency injecttion





// REGISTER IDENTITY START //
builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;
}

).AddEntityFrameworkStores<IdentityContext>();
   //.AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>(); // Denerate displayname from claims.




// Register CLAIMS End


// Register cookie service start //

builder.Services.ConfigureApplicationCookie(x =>
    {
        x.LoginPath = "/login";
        x.LogoutPath = "/";
        x.AccessDeniedPath = "/Denied/DeniedIndex";

    });

//register cookie service end



//builder.Services.AddAuthorization(options =>
//{

//    options.AddPolicy("SystemAdminOnly", policy =>
//    {
//        policy.RequireRole("System Administrator");
//    });
//});




var app = builder.Build();



app.UseHsts();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization(); // Move this line after app.UseRouting()
app.UseStaticFiles();
app.UseAuthentication(); 



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=HomeIndex}/{id?}");

app.Run();