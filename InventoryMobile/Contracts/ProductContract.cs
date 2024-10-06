using Flunt.Validations;
using InventoryMobile.Models.Request;

namespace InventoryMobile.Contracts
{
    public class ProductContract : Contract<ProductRequest>
    {
        public ProductContract(ProductRequest productRequest)
        {
            Requires()
                .IsNotEmpty(productRequest.ProductId, nameof(productRequest.ProductId), "Id is required");

            Requires()
                .IsNotNullOrEmpty(productRequest.Description, nameof(productRequest.Description), "Description cannot be empty");

            Requires()
                .IsGreaterThan(productRequest.Storaged, -1, nameof(productRequest.Storaged), "Storage cannot be negative");

            Requires()

                .IsNotNullOrEmpty(productRequest.BarCode, nameof(productRequest.BarCode), "Code bar cannot be empty");

            Requires()
                .IsGreaterThan(productRequest.Price, 0, nameof(productRequest.Price), "The price have to be greater than zero");
        }
    }
}
