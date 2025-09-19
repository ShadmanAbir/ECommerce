using ECommerce.API.Models;
using ECommerce.API.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ECommerce.API.Services
{
    public class ProductService
    {
        private readonly ECommerceContext _context;

        public ProductService(ECommerceContext context)
        {
            _context = context;
        }

        public async Task<List<ProductViewModel>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .Select(p => new ProductViewModel
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    BasePrice = p.BasePrice,
                    //Stock = p.Stock,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category!.Name,
                    //Attributes = p.Attributes != null
                    //    ? JsonSerializer.Deserialize<Dictionary<string, string>>(p.Attributes)
                    //    : null
                }).ToListAsync();
        }

        public async Task<ProductViewModel?> GetProductByIdAsync(int id)
        {
            var p = await _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (p == null) return null;

            return new ProductViewModel
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                BasePrice = p.BasePrice,
                //Stock = p.Stock,
                CategoryId = p.CategoryId,
                CategoryName = p.Category!.Name,
                //Attributes = p.Attributes != null
                //    ? JsonSerializer.Deserialize<Dictionary<string, string>>(p.Attributes)
                //    : null
            };
        }

        public async Task<ProductViewModel> CreateProductAsync(ProductViewModel model)
        {
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                BasePrice = model.BasePrice,
                //Stock = model.Stock,
                CategoryId = model.CategoryId,
                //Attributes = model.Attributes != null ? JsonSerializer.Serialize(model.Attributes) : null
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            model.ProductId = product.ProductId;
            return model;
        }

        public async Task<ProductViewModel?> UpdateProductAsync(int id, ProductViewModel model)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;

            product.Name = model.Name;
            product.Description = model.Description;
            product.BasePrice = model.BasePrice;
            //product.Stock = model.Stock;
            product.CategoryId = model.CategoryId;
            //product.Attributes = model.Attributes != null ? JsonSerializer.Serialize(model.Attributes) : null;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
