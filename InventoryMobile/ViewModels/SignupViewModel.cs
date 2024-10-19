using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using InventoryMobile.Contracts;
using InventoryMobile.Models.Request;
using InventoryMobile.Repositories.Signup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMobile.ViewModels
{
    public partial class SignupViewModel : BaseViewModel
    {
        [ObservableProperty]
        string name;

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        private readonly ISignupRepository _signupRepository;
        public SignupViewModel(ISignupRepository signupRepository)
        {
            _signupRepository = signupRepository;
        }

        [RelayCommand]
        public async Task Signup()
        {
            var request = new SignupRequest(Name, Email, Password);

            var contract = new SignupContract(request);

            if (!contract.IsValid)
            {
                var messages = contract.Notifications.Select(x => x.Message);   
                var stringBuilder = new StringBuilder();

                foreach (var message in messages)                
                    stringBuilder.AppendLine($"{message.ToString()}/n");

                await Shell.Current.DisplayAlert("Warning", stringBuilder.ToString(), "OK");

                
            }

            var result = await _signupRepository.CreateAsyn(request);

            if (result)
            {
                var toast = Toast.Make("User is registered!", ToastDuration.Long);

                await toast.Show();

                await Shell.Current.GoToAsync("..");
            }
            else
            {
                var toast = Toast.Make("Error! User is not registered!", ToastDuration.Long);

                await toast.Show();
            }
        }


    }
}
