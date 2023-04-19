using AssignmentMVC.Contexts;
using AssignmentMVC.Models.Entities;
using AssignmentMVC.Services.ProductServices;
using AssignmentMVC.ViewModels.RegisterProduct;
using Microsoft.AspNetCore.Mvc;
using static AssignmentMVC.Services.ProductServices.ProductService;

namespace AssignmentMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContexts _context;
        private readonly ProductService _productService;

        public ProductController(ProductService productService, DataContexts context)
        {
            _productService = productService;
            _context = context;
        }

        public IActionResult ProductPageIndex()
        {
            return View();
        }

        public IActionResult ProductIndex()
        {
            return View();
        }
        
        public IActionResult RegisterProduct()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Register(ProductRegistrationViewModel productRegistrationViewModel, bool isNew, bool isPopular, bool isFeatured)
        {
            if (!ModelState.IsValid)
            {
                return View(productRegistrationViewModel);
            }

            productRegistrationViewModel.IsNew = isNew;
            productRegistrationViewModel.IsPopular = isPopular;
            productRegistrationViewModel.IsFeatured = isFeatured;

            var entity = productRegistrationViewModel.ToProductEntity();
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();

            return RedirectToAction("HomeIndex", "Home");
        }

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
