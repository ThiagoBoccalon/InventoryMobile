using CommunityToolkit.Maui.Alerts;
using InventoryMobile.Contracts;
using InventoryMobile.Models.Request;
using InventoryMobile.Repositories.Product;
using System.Text;

namespace InventoryMobile.ViewModels
{
    public partial class AddProductViewModel : BaseViewModel
    {
        [ObservableProperty]
        string barcode;

        [ObservableProperty]
        string description;

        [ObservableProperty]
        int? storage;

        [ObservableProperty]
        double? price;

        private readonly IProductRepository _productRepository;

        public AddProductViewModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [RelayCommand]
        public async Task Save()
        {
            var productRequest = new ProductRequest(
                Description,
                Storage.Value,
                Barcode,
                "Unit",
                Price.Value,
                DateTime.Now
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

            var result = await _productRepository.AddAsync(productRequest);

            if (!result)
            {
                var toast = Toast.Make("Add new product has failed",
                    CommunityToolkit.Maui.Core.ToastDuration.Long);

                await toast.Show();
                return;
            }

            var toastSucess = Toast.Make("Product has storeged!",
                    CommunityToolkit.Maui.Core.ToastDuration.Long);

            toastSucess.Show();

            await Shell.Current.GoToAsync("..");
        }
    }
}
