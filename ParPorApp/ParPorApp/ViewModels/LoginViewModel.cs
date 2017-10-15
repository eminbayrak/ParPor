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
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    ApiServices apiServices = new ApiServices();
                    await apiServices.LoginUserAsync(Email, Password);
                });
            }
        }
    }
}
