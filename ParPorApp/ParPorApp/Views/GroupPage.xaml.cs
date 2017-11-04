using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ParPorApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParPorApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GroupPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public GroupPage()
        {
            InitializeComponent();

            groupView.ItemsSource = new List<Group>
            {
                new Group{ Name = "Ashley O'Toole", ImageUrl = "princetonSoccer.png", Description = "Main O'Toole's parent"},
                new Group{ Name = "Andrue Steven", ImageUrl = "princetonSoccer.png", Description = "Charlie Steven's parent"}
            };
        }

        async void GroupView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var contact = e.SelectedItem as Group;
            await Navigation.PushAsync(new ContactDetailPage(contact));
            groupView.SelectedItem = null;
        }
    }
}
