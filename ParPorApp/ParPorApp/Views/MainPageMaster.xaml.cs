using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ParPorApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParPorApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageMaster : ContentPage
    {
        public ListView ListView;

        public MainPageMaster()
        {
            InitializeComponent();

            BindingContext = new MainPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MainPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainPageMenuItem> MenuItems { get; set; }

            public MainPageMasterViewModel()
            {

                MenuItems = new ObservableCollection<MainPageMenuItem>(new[]
                {

                    new MainPageMenuItem { Id = 0, Title = "My Group", Icon = "ic_meetup", TargetType=typeof(GroupPage)},
                    new MainPageMenuItem { Id = 1, Title = "Social", Icon = "ic_meetup", TargetType=typeof(SocialPage)},
                    new MainPageMenuItem { Id = 2, Title = "Events", Icon = "ic_meetup", TargetType=typeof(ApiPage) },
                    new MainPageMenuItem { Id = 3, Title = "Schedule", Icon = "ic_meetup", TargetType=typeof(EventsPage) },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}