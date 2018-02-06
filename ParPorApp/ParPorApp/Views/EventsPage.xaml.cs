using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParPorApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public class Event
    {
        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("EndDateTime")]
        public string EndDateTime { get; set; }

        [JsonProperty("GroupId")]
        public string GroupId { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("LocationId")]
        public string LocationId { get; set; }

        [JsonProperty("StartDateTime")]
        public string StartDateTime { get; set; }
    }
    public partial class EventsPage : ContentPage
    {
        private const string Url = "http://parentportalapi.azurewebsites.net/api/events";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<Event> _events;

        public EventsPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);
            var events = JsonConvert.DeserializeObject<List<Event>>(content);
            _events = new ObservableCollection<Event>(events);
            eventsListView.ItemsSource = _events;

            base.OnAppearing();
        }
    }
}