using AssignmentMVC.Contexts;
using AssignmentMVC.Models.Entities;
using AssignmentMVC.Models.Models;
using AssignmentMVC.ViewModels.RegisterProduct;
using Microsoft.EntityFrameworkCore;

namespace AssignmentMVC.Services.ProductServices;


public class ProductService
{
    private readonly DataContexts _context;

    public ProductService(DataContexts context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(ProductRegistrationViewModel productRegistrationViewModel)
    {
        try
        {
            ProductEntity productEntity = productRegistrationViewModel;

            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();
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




    public async Task<IEnumerable<ProductModel>> GetAllAsync()
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

    public async Task<ProductModel> GetByIdAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            throw new ArgumentException($"Product with id {id} not found.");
        }

        return product;
    }

    public async Task<IEnumerable<ProductModel>> GetEightAsync()
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


}



