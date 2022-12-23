using ECommerce.Core.ViewModels;

namespace ECommerce.Core.Interfaces
{
    public interface IProductService
    {
        public ProductViewModel GetProductByID(int ProductID);
        public List<ProductViewModel> GetAllProduct();
        public int CreateProduct(ProductViewModel productVM);
        public int UpdateProduct(ProductViewModel productVM);
    }
}
