using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ParPorApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParPorApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TablePage : ContentPage
	{
  //      private const string Url = "http://localhost:55600/api/groups";
  //      private HttpClient _client = new HttpClient();
  //      private ObservableCollection<ApiGroup> _groups;
  //      public TablePage ()
		//{
		//	InitializeComponent ();

		    
  //      }
	 //   protected override async void OnAppearing()
	 //   {
	 //       var content = await _client.GetStringAsync(Url);
	 //       var groups = JsonConvert.DeserializeObject<List<ApiGroup>>(content);
	 //       _groups = new ObservableCollection<ApiGroup>(groups);
	 //       tableView.ItemsSource = _groups;


	 //   }
  //      async void TableView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	 //   {
	 //       if (e.SelectedItem == null)
	 //           return;
	 //       var contact = e.SelectedItem as Group;
	 //       await Navigation.PushAsync(new ContactDetailPage(contact));
	 //       tableView.SelectedItem = null;
	 //   }
        
    }

}