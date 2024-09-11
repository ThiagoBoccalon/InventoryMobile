using Flurl;
using Flurl.Http;
using InventoryMobile.Helpers;
using InventoryMobile.Models.Request;
using InventoryMobile.Models.Response;

namespace InventoryMobile.Repositories.Login
{
    public class LoginRepository : ILoginRepository
    {
        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            var response = await Constants.ApiUrl
                .AppendPathSegments("/users/login")
                .PutJsonAsync(loginRequest);

            if (response.ResponseMessage.IsSuccessStatusCode)
            {
                var content = await response.ResponseMessage.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<LoginResponse>(content);
            }

            return new LoginResponse();
        }
    }
}
