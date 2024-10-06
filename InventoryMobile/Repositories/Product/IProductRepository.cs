using InventoryMobile.Models.Request;
using InventoryMobile.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMobile.Repositories.Product
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductResponse>> GetProductAsync();
        Task<bool> AddAsync(ProductRequest productRequest);
        Task<bool> UpdateAsync(ProductRequest productRequest);
        Task<ProductResponse> GetProductBarCodeAsync(string barcode);
    }
}
