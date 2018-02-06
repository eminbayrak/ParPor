using Android.App;
using Android.Content.PM;
using Android.OS;
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
            

            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            CurrentPlatform.Init();
            LoadApplication(new App());
            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeModule());

        }
    }
}