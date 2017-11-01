using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ParPorApp.Views;
using Xamarin.Forms;

namespace ParPorApp.Models
{
    class MasterViewModel
    {
        public ICommand NavigationCommand

        {

            get

            {

                return new Command((value) =>

                {

                    var mdp = (Application.Current.MainPage as MasterDetailPage);

                    var navPage = mdp.Detail as NavigationPage;



                    // Hide the Master page

                    mdp.IsPresented = false;



                    switch (value)

                    {

                        case "1":

                            navPage.PushAsync(new SocialPage());

                            break;

                        case "2":

                            navPage.PushAsync(new EventsPage());

                            break;

                        //case "3":

                        //    navPage.PushAsync(new SchedulePage());

                        //    break;

                    }



                });

            }

        }
    }
}
