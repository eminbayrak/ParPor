using ParPorApp.Views;
using ParPorApp.Helpers;
using ParPorApp.ViewModels;
using Xamarin.Forms;

namespace ParPorApp
{
    public partial class App : Application
    {
        public static uint AnimationSpeed = 250;
        public static int DelaySpeed = 300;
        static App _instance;
        public App()
        {
            InitializeComponent();

            if (!Settings.IsLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new WelcomePage());
            }

        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
