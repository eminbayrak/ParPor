﻿using ParPorApp.Helpers;
using ParPorApp.ViewModels;
using ParPorApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
 using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace ParPorApp.ViewModels
{
    internal class EventsViewModel : INotifyPropertyChanged
    {
        private readonly ApiServices _apiServices = new ApiServices();
        private List<Events> _event;


        public string AccessToken { get; set; }

        public List<Events> Event
        {
            get => _event;
            set
            {
                _event = value;
                OnPropertyChanged();
            } 
        }

        public ICommand GetEventsCommand
        {
            get
            { return new Command(async () =>
              {
                Event = await _apiServices.GetEventsAsync(AccessToken);
              });
            }
        }

        public ICommand LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    Settings.AccessToken = string.Empty;
                    Debug.WriteLine(Settings.Username);
                    Settings.Username = string.Empty;
                    Debug.WriteLine(Settings.Password);
                    Settings.Password = string.Empty;

                    // navigate to LoginPage
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
