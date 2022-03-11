using Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Front.Services
{
    internal class TaskService
    {
        const string Url = "http://192.168.1.86:5000/app/Task/";

        public async Task<List<TaskModel>> GetTasks()
        {
            var client = new HttpClient(GetInsecureHandler());
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var result = await client.GetAsync(Url + $"GetTasks/{Preferences.Get("current_plan", 0)}");
            var tasks = JsonConvert.DeserializeObject<List<TaskModel>>(await result.Content.ReadAsStringAsync());
            return tasks;
        }

        public async Task<bool> EditTasks(TaskModel task)
        {
            var client = new HttpClient(GetInsecureHandler());
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var result = await client.PutAsync(Url + $"EditTask", 
                new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8, "application/json"));
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTasks(int id)
        {
            var client = new HttpClient(GetInsecureHandler());
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var result = await client.DeleteAsync(Url + $"DeleteTask/{id}");
            return result.IsSuccessStatusCode;
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
