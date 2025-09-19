using ECommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Services
{
    public class ProductService
    {
        private readonly ECommerceContext _context;

        public ProductService(ECommerceContext context)
        {
            _context = context;
        }

        // Create new product
        public async Task<Product> CreateProductAsync(Product product)
        {
            product.CreatedAt = DateTime.UtcNow;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        // Get product by Id
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        // Get all products (optionally by category)
        public async Task<List<Product>> GetProductsAsync(int? categoryId = null)
        {
            var query = _context.Products.Include(p => p.Category).AsQueryable();

            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        // Update product details
        public async Task<Product?> UpdateProductAsync(int id, Product updatedProduct)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;

            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.BasePrice = updatedProduct.BasePrice;
            product.CategoryId = updatedProduct.CategoryId;
            product.Attributes = updatedProduct.Attributes; // JSONB dynamic attributes
            product.CreatedAt = DateTime.UtcNow;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        // Delete product
        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        // Search products by keyword (name/description)
        public async Task<List<Product>> SearchProductsAsync(string keyword)
        {
            return await _context.Products
                .Where(p => p.Name.ToLower().Contains(keyword.ToLower()) ||
                            p.Description.ToLower().Contains(keyword.ToLower()))
                .AsNoTracking()
                .ToListAsync();
        }

        // Filter by JSONB attributes (Postgres only)
        public async Task<List<Product>> FilterByAttributeAsync(string attributeKey, string attributeValue)
        {
            return await _context.Products
                .Where(p => EF.Functions.JsonContains(p.Attributes!, $"{{\"{attributeKey}\": \"{attributeValue}\"}}"))
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
