using Flunt.Validations;
using InventoryMobile.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InventoryMobile.Contracts
{
    public class LoginContract : Contract<LoginRequest>
    {
        public LoginContract(LoginRequest request)
        {
            Requires()
                .IsNotNullOrEmpty(request.Email, "Email", "Email can't be empty.")
                .IsEmail(request.Email, "Email", "This e-mail is not acceptable")
                .IsNotNullOrEmpty(request.Password, "Password", "Password can't be empty");
        }
    }
}
