using AssignmentMVC.Contexts;
using AssignmentMVC.Repositories;
using AssignmentMVC.Services.Authentication;
using AssignmentMVC.Services.ProductServices;
using AssignmentMVC.Services.ShowCaseServices;
using AssignmentMVC.Services.UpToSaleService;
using Microsoft.EntityFrameworkCore;
using static AssignmentMVC.Services.ShowCaseServices.ShowCaseService;

var builder = WebApplication.CreateBuilder(args);


// ADD DATACONTEXT START
builder.Services.AddDbContext<DataContexts>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ProductSql")));
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("UserSql")));


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
