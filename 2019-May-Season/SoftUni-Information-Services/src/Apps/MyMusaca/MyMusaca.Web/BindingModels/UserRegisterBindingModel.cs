using SIS.MvcFramework.Attributes.Validation;

namespace MyMusaca.Web.BindingModels
{
    public class UserRegisterBindingModel
    {
        private const string UsernameErrorMessage = "Username length is invalid, must be between 5 and 20 symbols.";
        private const string EmailErrorMessage = "Email length is invalid, must be between 5 and 20 symbols.";

        [RequiredSis]
        [StringLengthSis(5, 20, UsernameErrorMessage)]
        public string Username { get; set; }

        [RequiredSis]
        public string Password { get; set; }

        [RequiredSis]
        public string ConfirmPassword { get; set; }

        [RequiredSis]
        [StringLengthSis(5, 20, EmailErrorMessage)]
        public string Email { get; set; }

    }
}