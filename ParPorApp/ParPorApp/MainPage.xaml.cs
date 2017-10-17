using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParPorApp.Views;
using Xamarin.Forms;

namespace ParPorApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //Navigation.PushModalAsync(new MasterDetailPage()
            //{
            //    Master = new HomePage(),
            //    Detail = new NavigationPage(new MainPage())
            //});
        }
    }
}
