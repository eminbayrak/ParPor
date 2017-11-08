using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.RestClient;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParPorApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            Title = "Welcome!";
        }

        private async void ButtonLogin_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());

        }
    }
}
