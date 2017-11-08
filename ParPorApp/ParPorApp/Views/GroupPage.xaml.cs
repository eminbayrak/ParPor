using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ParPorApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParPorApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class ApiGroup
    {
        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("DistrictId")]
        public string DistrictId { get; set; }

        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }

    
    public partial class GroupPage : ContentPage
    {
        //private const string Url = "http://localhost:55000/api/groups";
        //private HttpClient _client = new HttpClient();
        //private ObservableCollection<ApiGroup> _groups;

        public ObservableCollection<string> Items { get; set; }

        public GroupPage()
        {
            InitializeComponent();

            groupView.ItemsSource = new List<Group>
            {
                new Group{ Name = "Ashley O'Toole", ImageUrl = "fa-cog", Description = "Main O'Toole's parent", Phone = "555-555-5555", Email = "ashley@mail.com"},
                new Group{ Name = "Andrue Stephen", ImageUrl = "princetonSoccer", Description = "Carlie Stephen's parent", Phone = "555-555-5555", Email = "andrue@mail.com"},
                new Group{ Name = "Alexis Alper", ImageUrl = "princetonSoccer", Description = "Addison Alper's parent", Phone = "555-555-5555", Email = "alexis@mail.com"},
                new Group{ Name = "Rhonda Shay", ImageUrl = "princetonSoccer", Description = "Caitlyn Shay's parent", Phone = "555-555-5555", Email = "rhonda@mail.com"},
                new Group{ Name = "Catherine Mason", ImageUrl = "princetonSoccer", Description = "Allison's parent", Phone = "555-555-5555", Email = "catherine@mail.com"},
                new Group{ Name = "Elise Wene", ImageUrl = "princetonSoccer", Description = "Grace Wene's parent", Phone = "555-555-5555", Email = "kacey@mail.com"},
                new Group{ Name = "Hannah Kemen", ImageUrl = "princetonSoccer", Description = "Haley Kemen's parent", Phone = "555-555-5555", Email = "hannah@mail.com"},
                new Group{ Name = "Kacey Bail", ImageUrl = "princetonSoccer", Description = "Charlie Steven's parent", Phone = "555-555-5555", Email = "kacey@mail.com"}
            };
            base.OnAppearing();
        }
        //protected override async void OnAppearing()
        //{
        //    var content = await _client.GetStringAsync(Url);
        //    var groups = JsonConvert.DeserializeObject<List<ApiGroup>>(content);
        //    _groups = new ObservableCollection<ApiGroup>(groups);
        //    groupView.ItemsSource = _groups;

           
        //}

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
