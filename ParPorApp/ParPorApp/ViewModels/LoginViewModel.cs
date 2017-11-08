﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ParPorApp.Helpers;
using ParPorApp.Services;
using ParPorApp.Views;
using Xamarin.Forms;

namespace ParPorApp.ViewModels
{
    public class LoginViewModel
    {
        private ApiServices _apiServices = new ApiServices();
        public string Email { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    
                    await Task.Run(() =>
                    {
                        return _apiServices.LoginUserAsync(Email, Password);
                    });
                    await ExecuteLoginCommandAsync();
                });
            }
        }

        async Task ExecuteLoginCommandAsync()
        {
            // Simple authentication for now
            bool loggedIn = true;

            // Show the root tab controller
            await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
        }
    }
}

