using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ParPorApp.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ParPorApp.Services
{
    public class ApiServices
    {
        public async Task RegisterUserAsync(string email, string password, string confirmPassword)
        {
            var client = new HttpClient();
            //var success = false;
            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };
            var json = JsonConvert.SerializeObject(model);
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(
                Constants.BaseApiAddress + "api/Account/Register", content);
                Debug.WriteLine(response);
                Debug.WriteLine(await response.Content.ReadAsStringAsync());
                Debug.WriteLine(response.StatusCode);

            //try
            //{
            //    var json = JsonConvert.SerializeObject(model);
            //    HttpContent content = new StringContent(json);
            //    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //    if (email != null || password != null)
            //    {
            //        success = true;
            //        Acr.UserDialogs.UserDialogs.Instance.ShowSuccess(string.Format("You are now signed-in as {0}.", email));
            //        var response = await client.PostAsync(
            //            Constants.BaseApiAddress + "api/Account/Register", content);
            //        Debug.WriteLine(response);
            //        Debug.WriteLine(await response.Content.ReadAsStringAsync());
            //        Debug.WriteLine(response.StatusCode);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Acr.UserDialogs.UserDialogs.Instance.ShowError(string.Format("Authentication Failed: {0}", ex.Message));
            //}
        }

        // Login user
        public async Task LoginUserAsync(string email, string password)
        {
            var client = new HttpClient();
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", email),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, Constants.BaseApiAddress + "Token");

            request.Content = new FormUrlEncodedContent(keyValues);
            
            try
            {
                var response = await client.SendAsync(request);
                //Acr.UserDialogs.UserDialogs.Instance.ShowSuccess("Logining...", 1500);
                //Acr.UserDialogs.UserDialogs.Instance.ShowError(await response.Content.ReadAsStringAsync());

                Debug.WriteLine(response);
                Debug.WriteLine(await response.Content.ReadAsStringAsync());
                Debug.WriteLine(response.StatusCode);
            }
            catch (Exception ex)
            {
                Acr.UserDialogs.UserDialogs.Instance.ShowError(ex.Message);
            }
        }
    }
}

