using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParPorApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    
    public partial class EventsPage : ContentPage
    {
        public EventsPage()
        {
            InitializeComponent();
        }

        private async void LogoutMenuItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}