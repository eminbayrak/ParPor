using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ParPorApp.Services;
using Xamarin.Forms;

namespace ParPorApp.ViewModels
{
    public class RegisterViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    ApiServices apiServices = new ApiServices();
                    await Task.Run(() =>
                    {
                        return apiServices.RegisterUserAsync(Email, Password, ConfirmPassword);
                    });
                    //if (isRegistered)
                    //{
                    //    Acr.UserDialogs.UserDialogs.Instance.ShowSuccdess("Success :)");
                    //}
                    //else
                    //{
                    //    Acr.UserDialogs.UserDialogs.Instance.ShowError("Please try again :(");
                    //}
                });
            }
        }
    }
}
