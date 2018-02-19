using System.Collections.Generic;
using System.Collections.ObjectModel;
using ParPorApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParPorApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    //public class ApiGroup
    //{
    //    public string Description { get; set; }
        
    //    public string DistrictId { get; set; }
        
    //    public long Id { get; set; }
        
    //    public string Name { get; set; }
    //}

    
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
                new Group{ Name = "Ashley O'Toole", ImageUrl = "https://ui-avatars.com/api/?background=c357&color=fff&name=A+O", Description = "Main O'Toole's parent", Phone = "555-555-5555", Email = "ashley@mail.com"},
                new Group{ Name = "Andrue Stephen", ImageUrl = "https://ui-avatars.com/api/?background=a457&color=ffff&name=A+S", Description = "Carlie Stephen's parent", Phone = "555-555-5555", Email = "andrue@mail.com"},
                new Group{ Name = "Alexis Alper", ImageUrl = "https://ui-avatars.com/api/?background=2267&color=ffff&name=A+A", Description = "Addison Alper's parent", Phone = "555-555-5555", Email = "alexis@mail.com"},
                new Group{ Name = "Rhonda Shay", ImageUrl = "https://ui-avatars.com/api/?background=6737&color=ffff&name=R+S", Description = "Caitlyn Shay's parent", Phone = "555-555-5555", Email = "rhonda@mail.com"},
                new Group{ Name = "Catherine Mason", ImageUrl = "https://ui-avatars.com/api/?background=c334&color=ffff&name=C+M", Description = "Allison's parent", Phone = "555-555-5555", Email = "catherine@mail.com"},
                new Group{ Name = "Elise Wene", ImageUrl = "https://ui-avatars.com/api/?background=e461&color=ffff&name=E+W", Description = "Grace Wene's parent", Phone = "555-555-5555", Email = "kacey@mail.com"},
                new Group{ Name = "Hannah Kemen", ImageUrl = "https://ui-avatars.com/api/?background=4654&color=ffff&name=H+K", Description = "Haley Kemen's parent", Phone = "555-555-5555", Email = "hannah@mail.com"},
                new Group{ Name = "Kacey Bail", ImageUrl = "https://ui-avatars.com/api/?background=f2d1&color=ffff&name=K+B", Description = "Charlie Steven's parent", Phone = "555-555-5555", Email = "kacey@mail.com"}
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
