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
                .IsNotNullOrEmpty(request.Password, "Password", "Password can't be empty")
                .IsTrue(CheckPasswordIsValid(request.Password), "Password is not acceptable, your email must have upper latters, lower latters, numubers and characteres");
        }

        private bool CheckPasswordIsValid(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return false;

            // Regular expression to validate password
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            // Returns true if the password matches the regex, otherwise false
            return regex.IsMatch(password);
        }
    }
}
