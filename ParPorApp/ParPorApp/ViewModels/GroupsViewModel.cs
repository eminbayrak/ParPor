using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Newtonsoft.Json;
using ParPorApp.Helpers;
using ParPorApp.Services;
using Xamarin.Forms;

namespace ParPorApp.ViewModels
{
    internal class GroupsViewModel : INotifyPropertyChanged
    {
        private readonly ApiServices _apiServices = new ApiServices();
        private List<Group> _groups;

        //public string AccessToken { get; set; }

        public List<Group> Groups
        {
            get => _groups;
            set
            {
                _groups = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetGroupsCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accessToken = Settings.AccessToken;
                    Groups = await _apiServices.GetGroupsAsync(accessToken);
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
