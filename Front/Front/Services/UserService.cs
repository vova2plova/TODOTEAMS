using Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Services
{
    public class UserService
    {
        const string Url = "http://192.168.1.86:5000/app/User";
        public async Task<User> AddNewUser(User user)
        {
            var client = new HttpClient(GetInsecureHandler());
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var result = await client.PostAsync(Url + "/registration",
                new StringContent(JsonConvert.SerializeObject(user),Encoding.UTF8, "application/json"));
            if (result.StatusCode != HttpStatusCode.OK)
                return (null);
            return JsonConvert.DeserializeObject<User>(await result.Content.ReadAsStringAsync());
        }

        public async Task<User> LogIn(User user)
        {
            var client = new HttpClient(GetInsecureHandler());
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var result = await client.GetAsync(Url + $"/login/{user.Login}/{user.Password}");
            if (result.StatusCode != HttpStatusCode.OK)
                return (null);
            return JsonConvert.DeserializeObject<User>(await result.Content.ReadAsStringAsync());
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
