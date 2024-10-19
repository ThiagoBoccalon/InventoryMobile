using CommunityToolkit.Maui.Alerts;
using InventoryMobile.Contracts;
using InventoryMobile.Models.Request;
using InventoryMobile.Models.Response;
using InventoryMobile.Repositories.Product;
using System.Text;

namespace InventoryMobile.ViewModels
{
    [QueryProperty(nameof(Product), nameof(Product))]
    public partial class EditProductViewModel : BaseViewModel
    {
        private ProductResponse _product;
        public ProductResponse Product
        {
            get => _product;
            set
            {
                SetProperty(ref _product, value);

                if (value != null)
                {
                   ProductId = value.ProductId;
                   Barcode = value.BarCode;
                   Description = value.Description;
                   Storaged = value.Storaged;
                   Price = value.Price;
                }
            }
        }

        [ObservableProperty]
        Guid productId;

        [ObservableProperty]
        string barcode;

        [ObservableProperty]
        string description;
        [ObservableProperty]
        int storaged;
        [ObservableProperty]
        double? price;

        private readonly IProductRepository _productRepository;    
        public EditProductViewModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task GetInfoProductAsync(string barcode)
        {
            var product = await _productRepository.GetProductByBarCodeAsync(barcode);

            if (product is null)
                return;

            ProductId = product.ProductId;
            Barcode = product.BarCode;
            Description = product.Description;
            Storaged = product.Storaged;
            Price = product.Price;
        }


        [RelayCommand]
        public async Task Save()
        {
            var productRequest = new ProductRequest(
                ProductId,
                Description,
                Storaged,
                Barcode,
                Price
                );

            var contract = new ProductContract(productRequest);

            if (!contract.IsValid)
            {
                var messages = contract.Notifications.Select(x => x.Message);
                var sb = new StringBuilder();

                foreach (var message in messages)
                {
                    sb.Append($"{message}\n");
                }

                await Shell.Current.DisplayAlert("Warning", sb.ToString(), "OK");

                return;
            }

            var result = await _productRepository.UpdateAsync(productRequest);

            if (!result)
            {
                var toast = Toast.Make(
                    "It has failed to get update storage, try it again",
                    CommunityToolkit.Maui.Core.ToastDuration.Long);

                await toast.Show();

                return;
            }

            var toastSucess = Toast.Make("Starage has updated sucessful",
                CommunityToolkit.Maui.Core.ToastDuration.Long);
            await toastSucess.Show();

            await Shell.Current.GoToAsync($"//{nameof(ProductsPage)}");

        }

    }
}
