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
    public class SignupContract : Contract<SignupRequest>
    {
        public SignupContract(SignupRequest signupRequest)
        {
            Requires()
                .IsNotNullOrEmpty(signupRequest.Name, nameof(signupRequest.Name), "Name cannot be empty");

            Requires()
                .IsEmail(signupRequest.Email, nameof(signupRequest.Email), "E-mail is not valid")
                .IsNotNullOrEmpty(signupRequest.Email, nameof(signupRequest.Email), "E-mail cannot be empty");

            Requires()
                .IsNotNullOrEmpty(signupRequest.Password, nameof(signupRequest.Password), "Password cannot be empty")
                .IsTrue(CheckPasswordIsValid(signupRequest .Password), "Password is not acceptable, your email must have upper latters, lower latters, numubers and characteres");
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
