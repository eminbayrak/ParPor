using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParPorApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    public partial class ApiPage : ContentPage
    {
        private const string Url = "https://jsonplaceholder.typicode.com/posts";
        //private const string Url = "http://localhost:55600/api/Groups";
        private HttpClient client = new HttpClient();
        //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
        private ObservableCollection<Post> _posts;
        public ApiPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var content = await client.GetStringAsync(Url);
            var posts = JsonConvert.DeserializeObject<List<Post>>(content);
            _posts = new ObservableCollection<Post>(posts);
            postsListView.ItemsSource = _posts;

            base.OnAppearing();
        }
    }
}