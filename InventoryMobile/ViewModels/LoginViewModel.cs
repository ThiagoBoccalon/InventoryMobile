using CommunityToolkit.Maui.Alerts;
using InventoryMobile.Contracts;
using InventoryMobile.Models.Request;
using InventoryMobile.Repositories.Login;
using System.Text;

namespace InventoryMobile.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        private readonly ILoginRepository _loginRepository;
        public LoginViewModel(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [RelayCommand]
        public async Task Login()
        {
            var loginRequest = new LoginRequest(Email, Password);

            var contract = new LoginContract(loginRequest);

            if (!contract.IsValid)
            {
                var messages = contract.Notifications.Select(x => x.Message);
                var stringBuilder = new StringBuilder();

                foreach(var message in messages)
                    stringBuilder.Append($"{message}\n");

                await Shell.Current.DisplayAlert("Atention", stringBuilder.ToString(), "OK");
                return;
            }               

            var result = await _loginRepository.LoginAsync(loginRequest);

            if (result is null || string.IsNullOrEmpty(result.AcessToken))
            {
                var toast = Toast.Make("Failed to login, try again!", CommunityToolkit.Maui.Core.ToastDuration.Long);
                toast.Show();
                return;
            }
        }
    }
}
