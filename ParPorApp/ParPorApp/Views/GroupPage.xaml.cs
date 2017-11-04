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

            MyListView.ItemsSource = new List<Group>
            {
                new Group{ Name = "Princeton Vikings Soccer", ImageUrl = "princetonSoccer.png", Description = "Princeton High School Soccer Group"}
            };
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView) sender).SelectedItem = null;
        }
    }
}
