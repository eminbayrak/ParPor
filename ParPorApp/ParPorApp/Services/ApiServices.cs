using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using ParPorApp.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParPorApp.Helpers;
using ParPorApp.Views;
using Xamarin.Forms;


namespace ParPorApp.Services

{
    internal class ApiServices : Page
    {
        public async Task<bool> RegisterUserAsync(
            string email, string password, string confirmPassword)
        {
            var client = new HttpClient();

            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(
                Constants.BaseApiAddress + "api/Account/Register", httpContent);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }


        // Login user
        public async Task<string> LoginAsync(string userName, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(
                HttpMethod.Post, Constants.BaseApiAddress + "Token")
            {
                Content = new FormUrlEncodedContent(keyValues)
            };

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();

            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(content);

            var accessTokenExpiration = jwtDynamic.Value<DateTime>(".expires");
            var accessToken = jwtDynamic.Value<string>("access_token");

            Settings.AccessTokenExpirationDate = accessTokenExpiration;

            Debug.WriteLine(accessTokenExpiration);

            Debug.WriteLine(content);

            return accessToken;
        }

        // get group list
        public async Task<List<Group>> GetGroupsAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", accessToken);

            var json = await client.GetStringAsync(Constants.BaseApiAddress + "api/groups");

            var group = JsonConvert.DeserializeObject<List<Group>>(json);

            return group;
        }

        // get events list
        public async Task<List<Events>> GetEventsAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", accessToken);

            var json = await client.GetStringAsync(Constants.BaseApiAddress + "api/events");

            var events = JsonConvert.DeserializeObject<List<Events>>(json);

            return events;
        }
        

        //public class AzureDataService
        //{
        //    public MobileServiceClient MobileService { get; set; }
        //    private IMobileServiceSyncTable eventTable;

        //    public async Task Initialize()
        //    {
        //        MobileService = new MobileServiceClient("https://parentportal.azurewebsites.net");
        //        const string path = "syncstore.db";
        //        //setup local sqlite store and init
        //        var store = new MobileServiceSQLiteStore(path);
        //        store.DefineTable();
        //        await MobileService.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());
        //        //get sync table that will call out azure
        //        eventTable = MobileService.GetSyncTable();

        //    }

        //    public async Task SyncEvent()
        //    {
        //        await eventTable.PullAsync("allEvents", eventTable.CreateQuery());
        //        await MobileService.SyncContext.PushAsync();
        //    }
        //}
    }
}
