using Ahmynar_MVC.Models;
using Ahmynar_MVC.Services.Base;

namespace Ahmynar_MVC.Contracts
{
    public interface IProductService
    {
        Task<List<ProductVM>> GetProducts();
        Task<ProductVM> GetProductDetails(int id);
        Task<Response<int>> CreateProduct(CreateProductVM product);
        Task<Response<int>> UpdateProduct(ProductVM product);
        Task<Response<int>> DeleteProduct(int id);
    }
}
