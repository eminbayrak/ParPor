using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ParPorApp.Helpers;
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

            public MainPageMasterViewModel() => MenuItems = new ObservableCollection<MainPageMenuItem>(new[]
            {

                new MainPageMenuItem { Id = 0, Title = "My Groups", IconSource="ic_group.png", TargetType=typeof(GroupPage)},
                new MainPageMenuItem { Id = 1, Title = "My Contacts", IconSource="ic_contacts.png", TargetType=typeof(SocialPage)},
                new MainPageMenuItem { Id = 2, Title = "My Messages", IconSource="ic_message.png", TargetType=typeof(ApiPage) },
                new MainPageMenuItem { Id = 3, Title = "Upcoming Events", IconSource="ic_group.png", TargetType=typeof(EventsPage) },
            });

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
        public ICommand LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    Settings.AccessToken = string.Empty;
                    Debug.WriteLine(Settings.Username);
                    Settings.Username = string.Empty;
                    Debug.WriteLine(Settings.Password);
                    Settings.Password = string.Empty;

                    // navigate to LoginPage
                });
            }
        }
        private async void LogoutMenuItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}