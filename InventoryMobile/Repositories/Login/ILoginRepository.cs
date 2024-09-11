using InventoryMobile.Models.Request;
using InventoryMobile.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMobile.Repositories.Login
{
    public interface ILoginRepository
    {
        Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
    }
}
