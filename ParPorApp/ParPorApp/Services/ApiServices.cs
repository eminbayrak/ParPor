using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ParPorApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParPorApp.Helpers;


namespace ParPorApp.Services

{
    internal class ApiServices
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

            var json = await client.GetStringAsync(Constants.BaseApiAddress + "api/group");

            var group = JsonConvert.DeserializeObject<List<Group>>(json);

            return group;
        }

        public async Task<List<Events>> GetEventsAsync(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", accessToken);

            var json = await client.GetStringAsync(Constants.BaseApiAddress + "api/events");

            var events = JsonConvert.DeserializeObject<List<Events>>(json);

            return events;
        }
    }
}