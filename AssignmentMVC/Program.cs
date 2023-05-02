using AssignmentMVC.Contexts;
using AssignmentMVC.Models.Identity;
using AssignmentMVC.Repositories;
using AssignmentMVC.Services.Authentication;
using AssignmentMVC.Services.ProductServices;
using AssignmentMVC.Services.ShowCaseServices;
using AssignmentMVC.Services.UpToSaleService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using static AssignmentMVC.Services.ShowCaseServices.ShowCaseService;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);


// ADD DATACONTEXT START
builder.Services.AddDbContext<DataContexts>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ProductSql")));
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("UserSql")));
builder.Services.AddDbContext<ContactContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ContactSql")));


// ADD DATACONTEXT END

// REGISTER SERVICES START //
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ShowCaseServices>(); //Added for Dependency injecttion
builder.Services.AddScoped<UpToSaleService>(); //Added for Dependency injecttion
builder.Services.AddScoped<ProductService>();  //Added for Dependency injecttion
builder.Services.AddScoped<AddressRepository>();  //Added for Dependency injecttion
builder.Services.AddScoped<UserAddressRepository>();  //Added for Dependency injecttion
builder.Services.AddScoped<AddressService>();  //Added for Dependency injecttion
builder.Services.AddScoped<AuthenticationService>();  //Added for Dependency injecttion



// REGISTER SERVICES END //

// REGISTER IDENTITY START //
builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;
}

).AddEntityFrameworkStores<IdentityContext>()
   .AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>(); // Denerate displayname from claims.




// Register CLAIMS End


// Register cookie service start //

builder.Services.ConfigureApplicationCookie(x =>
    {
        x.LoginPath = "/login";
        x.LogoutPath = "/";
        x.AccessDeniedPath = "/denied";

    });

//register cookie service end

var app = builder.Build();






app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=HomeIndex}/{id?}");

app.Run();


//BytMig123!