using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParPorApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SocialPage : TabbedPage
    {
        public SocialPage()
        {
            InitializeComponent();
            
            Children.Add(new LatestPage() { Title = "Events"});
            Children.Add(new TablePage() { Title = "Table" });
            Children.Add(new GamesPage() { Title = "Newsfeed" });
            
        }
    }
}