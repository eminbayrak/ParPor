using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParPorApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            EmailEntry.Completed += (object sender, EventArgs e) =>
            {
                PasswordEntry.Focus();
            };
            
            Init();
        }

        void Init()
        {
            LogoIcon.HeightRequest = Constants.LogoIconHeight;
        }
    }

}