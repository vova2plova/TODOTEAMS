using Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Front.Services
{
    internal class PlanService
    {
        const string Url = "http://192.168.1.86:5000/app/Plan/";

        public async Task<ObservableCollection<Plan>> GetPlans()
        {
            var client = new HttpClient(GetInsecureHandler());
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var result = await client.GetAsync(Url + $"GetAllPlans/{Preferences.Get("current_user_id", 0)}");
            var plans = JsonConvert.DeserializeObject<ObservableCollection<Plan>>(await result.Content.ReadAsStringAsync());
            return plans;
        }

        public async Task<bool> AddNewPlan(Plan plan)
        {
            var client = new HttpClient(GetInsecureHandler());
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var result = await client.PostAsync(Url + "AddNewPlan",
                new StringContent(JsonConvert.SerializeObject(plan), Encoding.UTF8, "application/json"));
            if (result.StatusCode != HttpStatusCode.OK)
                return false;
            return true;
        }

        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }
    }
}
