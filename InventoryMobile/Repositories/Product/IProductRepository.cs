using InventoryMobile.Models.Request;
using InventoryMobile.Models.Response;

namespace InventoryMobile.Repositories.Product
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductResponse>> GetProductAsync();
        Task<bool> AddAsync(ProductRequest productRequest);
        Task<bool> UpdateAsync(ProductRequest productRequest);
        Task<ProductResponse> GetProductByBarCodeAsync(string barcode);
    }
}
