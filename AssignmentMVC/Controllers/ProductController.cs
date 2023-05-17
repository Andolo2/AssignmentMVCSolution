using AssignmentMVC.AuthFilters;
using AssignmentMVC.Contexts;
using AssignmentMVC.Models.Entities;
using AssignmentMVC.Models.Identity;
using AssignmentMVC.Services.ProductServices;
using AssignmentMVC.ViewModels.RegisterProduct;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using static AssignmentMVC.Services.ProductServices.ProductService;

namespace AssignmentMVC.Controllers
{
    [TypeFilter(typeof(CustomAuthorizationFilter), Arguments = new object[] { "System Administrator" })]

    public class ProductController : Controller
    {
        private readonly DataContexts _context;
        private readonly ProductService _productService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<ProductController> _logger;
        private readonly UserManager<AppUser> _userManager;


        public ProductController(ProductService productService, DataContexts context, IWebHostEnvironment webHostEnvironment, ILogger<ProductController> logger, UserManager<AppUser> userManager)
        {
            _productService = productService;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
            _userManager = userManager;
        }










        public IActionResult ProductPageIndex()
        {
            return View();
        }

        public IActionResult ProductIndex()
        {
            return View();
        }


        //public async Task<IActionResult> RegisterProduct()
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        var user = await _userManager.GetUserAsync(User);
        //        var roles = await _userManager.GetRolesAsync(user);
        //        var userRole = roles.FirstOrDefault();

        //        _logger.LogInformation($"User '{User.Identity.Name}' is in role '{userRole}'.");
        //    }

        //    return View();
        //}
        public async Task<IActionResult> RegisterProduct()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                if (await _userManager.IsInRoleAsync(user, "System Administrator"))
                {
                    _logger.LogInformation($"User '{user.Email}' is  authenticated and has the 'System Administrator' role assigned.");
                }
                else
                {
                    _logger.LogInformation($"User '{user.Email}' is authenticated but does not have the 'System Administrator' role assigned.");
                }
            }
            else
            {
                _logger.LogInformation("User is not authenticated.");
            }

            return View();
        }

        //public IActionResult Register()
        //{
        //    return View();
        //}

        //[Authorize(Policy = "SystemAdminOnly")]
        [Authorize(Roles = "System Administrator")]
        [HttpPost]
        public async Task<IActionResult> Register(ProductRegistrationViewModel productRegistrationViewModel, bool isNew, bool isPopular, bool isFeatured)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(productRegistrationViewModel);
                }

                if (!User.Identity.IsAuthenticated)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var roles = await _userManager.GetRolesAsync(user);
                    var userRole = roles.FirstOrDefault();

                    _logger.LogInformation($"User '{User.Identity.Name}' is in role '{userRole}'.");
                }


                productRegistrationViewModel.IsNew = isNew;
                productRegistrationViewModel.IsPopular = isPopular;
                productRegistrationViewModel.IsFeatured = isFeatured;

                var product = await _productService.CreateAsync(productRegistrationViewModel);
                if (product != null)
                {
                    if (productRegistrationViewModel != null)
                        await _productService.UploadImageAsync(product, productRegistrationViewModel.Image!);


                    return RedirectToAction("ProductIndex", "Product");
                }




                var entity = productRegistrationViewModel.ToProductEntity();

                _context.Products.Add(entity);
                await _context.SaveChangesAsync();

                return RedirectToAction("HomeIndex", "Home");
            }
            catch
            {
                // Log 
                _logger.LogError("An error occurred while registering the product.");

                ViewBag.ErrorMessage = "An error occurred while registering the product.";
                return View();
            }

        }



























        //[Authorize(Roles = "System Administrator")]
        //[HttpPost]
        //public async Task<IActionResult> Register(ProductRegistrationViewModel productRegistrationViewModel, bool isNew, bool isPopular, bool isFeatured)
        //{

        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return View(productRegistrationViewModel);
        //        }

        //        if (!User.Identity.IsAuthenticated)
        //        {
        //            var user = await _userManager.GetUserAsync(User);
        //            var roles = await _userManager.GetRolesAsync(user);
        //            var userRole = roles.FirstOrDefault();

        //            _logger.LogInformation($"User '{User.Identity.Name}' is in role '{userRole}'.");
        //        }


        //            productRegistrationViewModel.IsNew = isNew;
        //        productRegistrationViewModel.IsPopular = isPopular;
        //        productRegistrationViewModel.IsFeatured = isFeatured;

        //        var product = await _productService.CreateAsync(productRegistrationViewModel);
        //        if (product != null)
        //        {
        //            if (productRegistrationViewModel != null)
        //                await _productService.UploadImageAsync(product, productRegistrationViewModel.Image!);


        //            return RedirectToAction("ProductIndex", "Product");
        //        }




        //        var entity = productRegistrationViewModel.ToProductEntity();

        //        _context.Products.Add(entity);
        //        await _context.SaveChangesAsync();

        //        return RedirectToAction("HomeIndex", "Home");
        //    }
        //    catch
        //    {
        //        // Log 
        //        _logger.LogError( "An error occurred while registering the product.");

        //        ViewBag.ErrorMessage = "An error occurred while registering the product.";
        //        return View();
        //    }

        //}












        public async Task<IActionResult> Delete(int id)
        {
            ProductEntity productEntity = await _context.Products.FindAsync(id);

            if (productEntity == null)
            {
                ModelState.AddModelError("", "Product not found");
                return View();
            }

            try
            {
                _context.Products.Remove(productEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Products");
            }
            catch
            {
                ModelState.AddModelError("", "Error deleting product");
                return View();
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                 ModelState.AddModelError("", "No products found");
                return NotFound();
            }

            ViewData["Id"] = id;

            return View(product);
        }



    }

}
