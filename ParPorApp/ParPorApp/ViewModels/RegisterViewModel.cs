using System.Windows.Input;
using ParPorApp.Services;
using Xamarin.Forms;
using ParPorApp.Helpers;

namespace ParPorApp.ViewModels
{
    public class RegisterViewModel
    {
        private readonly ApiServices _apiServices = new ApiServices();

        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Message { get; set; }
        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var isRegistered = await _apiServices.RegisterUserAsync
                        (Username, Password, ConfirmPassword);

                    Settings.Username = Username;
                    Settings.Password = Password;

                    if (isRegistered)
                    {
                        Message = "User succesfully registered :)";
                    }
                    else
                    {
                        Message = "Something went wrong. Please try again :(";
                    }
                });
            }
        }
    }
}
