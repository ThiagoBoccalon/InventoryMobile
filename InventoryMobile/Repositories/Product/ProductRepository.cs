using InventoryMobile.Models.Request;
using InventoryMobile.Models.Response;
using InventoryMobile.Helpers;
using Flurl;
using Flurl.Http;

namespace InventoryMobile.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        public async Task<bool> AddAsync(ProductRequest productRequest)
        {
            var response = await Constants.ApiUrl
                .AppendPathSegment("/products")
                .WithOAuthBearerToken(Preferences.Get("token", string.Empty))
                .PostJsonAsync(productRequest);

            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<ProductResponse>> GetProductAsync()
        {
            return await Constants.ApiUrl
                .AppendPathSegment("/products")
                .WithOAuthBearerToken(Preferences.Get("token", string.Empty))
                .GetJsonAsync<IEnumerable<ProductResponse>>();
        }

        public Task<bool> UpdateAsync(ProductRequest productRequest)
        {
            throw new NotImplementedException();
        }
    }
}
