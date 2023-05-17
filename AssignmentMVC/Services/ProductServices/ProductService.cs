using AssignmentMVC.Contexts;
using AssignmentMVC.Models.Entities;
using AssignmentMVC.Models.Models;
using AssignmentMVC.ViewModels.RegisterProduct;
using Microsoft.EntityFrameworkCore;

namespace AssignmentMVC.Services.ProductServices;


public class ProductService
{
    private readonly DataContexts _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProductService(DataContexts context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<ProductEntity> CreateAsync(ProductRegistrationViewModel productRegistrationViewModel)
    {
        try
        {
            ProductEntity productEntity = productRegistrationViewModel;

            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();
            return productEntity;
        }
        catch
        {
            return null;
        }
    }

    public async Task<bool> UploadImageAsync(ProductModel product, IFormFile image)
    {
        try
        {
            string imagePath = $"{_webHostEnvironment.WebRootPath}/images/FromForm/{product.ImageUrl}";
            await image.CopyToAsync(new FileStream(imagePath, FileMode.Create));
            return true;
        }
        catch
        {
            return false;
        }
    }






    public async Task<bool> DeleteAsync(int Id)
    {
        ProductEntity productEntity = await _context.Products.FindAsync(Id);

        try
        {


            if (productEntity == null)
            {
                return false;
            }

            _context.Products.Remove(productEntity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }




    public async Task<IEnumerable<ProductModel>> GetAllAsync() // Get all products
    {
        var products = new List<ProductModel>();

        var items = await _context.Products.ToListAsync();

        foreach (var item in items)
        {
            ProductModel productModel = item;
            products.Add(productModel);

        }
        return products;
    }

    public async Task<ProductModel> GetByIdAsync(int id) // Get by ID
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            throw new ArgumentException($"Product with id {id} not found.");
        }

        return product;
    }

    public async Task<IEnumerable<ProductModel>> GetEightAsync() // Get eight products
    {
        var products = new List<ProductModel>();

        var items = await _context.Products.Take(8).ToListAsync();

        foreach (var item in items)
        {
            ProductModel productModel = item;
            products.Add(productModel);
        }

        return products;
    }

    public async Task<IEnumerable<ProductModel>> GetTwoAsync() // Get two products
    {
        var products = new List<ProductModel>();

        var items = await _context.Products.Take(1).ToListAsync();

        foreach (var item in items)
        {
            ProductModel productModel = item;
            products.Add(productModel);
        }

        return products;
    }

    public async Task<IEnumerable<ProductModel>> GetSixAsync() // Get six products
    {
        var products = new List<ProductModel>();

        var items = await _context.Products.Take(6).ToListAsync();

        foreach (var item in items)
        {
            ProductModel productModel = item;
            products.Add(productModel);
        }

        return products;
    }

    public async Task<IEnumerable<ProductModel>> GetThreeAsync() // Get three products
    {
        var products = new List<ProductModel>();

        var items = await _context.Products.Take(3).ToListAsync();

        foreach (var item in items)
        {
            ProductModel productModel = item;
            products.Add(productModel);
        }

        return products;
    }

    public async Task<IEnumerable<ProductModel>> GetFourAsync() // Get four products
    {
        var products = new List<ProductModel>();

        var items = await _context.Products.Take(4).ToListAsync();

        foreach (var item in items)
        {
            ProductModel productModel = item;
            products.Add(productModel);
        }

        return products;
    }

    public async Task<IEnumerable<ProductModel>> GetFeaturedProductsAsync() // Get featured products
    {
        var products = await _context.Products
            .Where(p => p.IsFeatured)
            .Select(p => new ProductModel
            {
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                Title = p.Title,
                Price = p.Price,
                IsNew = p.IsNew,
                IsPopular = p.IsPopular,
                IsFeatured = p.IsFeatured
            })
            .ToListAsync();

        return products;
    }

    public async Task<IEnumerable<ProductModel>> GetNewProductsAsync() // Get new products
    {
        var products = await _context.Products
            .Where(p => p.IsNew)
            .Select(p => new ProductModel
            {
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                Title = p.Title,
                Price = p.Price,
                IsNew = p.IsNew,
                IsPopular = p.IsPopular,
                IsFeatured = p.IsFeatured
            })
            .ToListAsync();

        return products;
    }

    public async Task<IEnumerable<ProductModel>> GetPopularProductsAsync() // Get popular products
    {
        var products = await _context.Products
            .Where(p => p.IsPopular)
            .Select(p => new ProductModel
            {
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                Title = p.Title,
                Price = p.Price,
                IsNew = p.IsNew,
                IsPopular = p.IsPopular,
                IsFeatured = p.IsFeatured
            })
            .ToListAsync();

        return products;
    }



}



