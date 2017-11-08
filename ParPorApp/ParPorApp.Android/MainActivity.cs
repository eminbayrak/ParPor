using Android.App;
using Android.Content.PM;
using Android.OS;
using Auth0.OidcClient;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace ParPorApp.Droid
{
    [Activity(Label = "ParPorApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            

            var client = new Auth0Client(new Auth0ClientOptions
            {
                Domain = "parentportal.auth0.com",
                ClientId = "gVAvxHhgFiO1r99A5zvQWPlvsSJDiB2g",
                Activity = this
            });

            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            CurrentPlatform.Init();
            LoadApplication(new App());
        }
    }
}