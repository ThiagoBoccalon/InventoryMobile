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

        public async Task<ProductResponse> GetProductByBarCodeAsync(string barcode)
        {
            return await Constants.ApiUrl
                .AppendPathSegment($"/products/{barcode}")
                .WithOAuthBearerToken(Preferences.Get("token", string.Empty))
                .GetJsonAsync<ProductResponse>();
        }

        public async Task<bool> UpdateAsync(ProductRequest productRequest)
        {
            var response = await Constants.ApiUrl
                .AppendPathSegment($"/product/{productRequest.ProductId}")
                .WithOAuthBearerToken(Preferences.Get("token", string.Empty))
                .PutJsonAsync(productRequest);

            return response.ResponseMessage.IsSuccessStatusCode;
        }
    }
}
