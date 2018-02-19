using System;
using ParPorApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ParPorApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    
    public partial class GroupPage : ContentPage
    {
        GroupsViewModel groupsViewModel;
        public GroupPage()
        {
            InitializeComponent();

            
            BindingContext = groupsViewModel = new GroupsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            groupsViewModel.GetGroupsCommand.Execute(null);
        }

        //private async void LogoutMenuItem_Clicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new LoginPage());
        //}
    }
}