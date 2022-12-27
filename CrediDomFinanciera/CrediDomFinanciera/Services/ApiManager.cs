using CrediDomFinanciera.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrediDomFinanciera.Services
{
    public class ApiManager
    {
        private HttpClient client;


        private static ApiManager _instance;
        public static ApiManager GetInstance(string url)
        {
            if (_instance == null)
            {
                lock (typeof(ApiManager))
                {
                    if (_instance == null)
                    {
                        _instance = new ApiManager(url);
                    }
                }
            }

            return _instance;
        }

        private ApiManager(string url)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            client = new HttpClient(handler) { BaseAddress = new Uri(url) };
            client.Timeout.Add(new TimeSpan(0, 8, 0));
        }

        public static async Task<List<PrestamoDetalle>> GetPrestamoDetalle(string key)
        {
            var client = new HttpClient() { BaseAddress = new Uri("http://movilbusiness.com.do/eMovilBusiness/MovilBusinessApi/api/ReplicacionesSuscriptores/") };

            client.Timeout.Add(new TimeSpan(0, 8, 0));
            long PhoneNumber = 8299051291;
            var response = await client.PostAsync("GetClientesVersion", new StringContent(JsonConvert.SerializeObject(PhoneNumber), Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
            {
            }

            var PrestamoDetalle = await response.Content.ReadAsStringAsync();

            return JsonConvert
                .DeserializeObject<List<PrestamoDetalle>>
                (PrestamoDetalle);
        }

    }
}
