using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ParPorApp.Helpers;
using ParPorApp.Services;
using Xamarin.Forms;

namespace ParPorApp.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

//        public ICommand LoginCommand
//        {
//            get
//            {
//                return new Command(async () =>
//                {
//                    ApiServices apiServices = new ApiServices();
//                    await apiServices.LoginUserAsync(Email, Password);
//                });
//            }
//        }
        
            public ICommand loginCommand;

        public ICommand LoginCommand =>
            loginCommand ?? (loginCommand = new Command(async () =>
            {
                ApiServices apiServices = new ApiServices();
                await apiServices.LoginUserAsync(Email, Password);
                await ExecuteLoginCommandAsync();

            }));

        async Task ExecuteLoginCommandAsync()
        {
            // Simple authentication for now
            bool loggedIn = true;

            if (loggedIn)
            {
                // Show the root tab controller
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            }
            else
            {
                // Say something about wrong username/password
            }
        }
    }
}

