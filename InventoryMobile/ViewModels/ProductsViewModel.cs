using InventoryMobile.Models.Response;
using InventoryMobile.Repositories.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMobile.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        public ObservableCollection<ProductResponse> Products { get; set; }
            = new ObservableCollection<ProductResponse>();

        private readonly IProductRepository _productRepository;
        public ProductsViewModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        internal async Task InitiAsync()
        {
            IsBusy = true;

            var products = await _productRepository.GetProductAsync();

            Products.Clear();

            foreach (var product in products)
            {
                Products.Add(product);
            }

            IsBusy = false;
        }
    }
}
