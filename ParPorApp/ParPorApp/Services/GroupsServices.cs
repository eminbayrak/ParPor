using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParPorApp.Models;
using Xamarin.Forms;
using Plugin.RestClient;

namespace ParPorApp.Services
{
    public class GroupsServices
    {
        public async Task<List<Group>> GetGroupAsync()
        {
            RestClient<Group> restClient = new RestClient<Group>();
            var employeeList = await restClient.GetAsync();
            return employeeList;
        }
    }
}
