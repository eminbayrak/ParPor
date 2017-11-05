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
        private const string Url = "http://localhost:55000/api/groups";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<ApiGroup> _groups;

        //public ObservableCollection<string> Items { get; set; }

        public GroupPage()
        {
            InitializeComponent();

            //groupView.ItemsSource = new List<Group>
            //{
            //    new Group{ Name = "Ashley O'Toole", ImageUrl = "fa-cog", Description = "Main O'Toole's parent"},
            //    new Group{ Name = "Andrue Steven", ImageUrl = "fa-cog", Description = "Charlie Steven's parent"}
            //};
        }
        protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);
            var groups = JsonConvert.DeserializeObject<List<ApiGroup>>(content);
            _groups = new ObservableCollection<ApiGroup>(groups);
            groupView.ItemsSource = _groups;

            base.OnAppearing();
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
