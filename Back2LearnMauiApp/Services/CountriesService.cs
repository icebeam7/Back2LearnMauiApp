using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections.Generic;

using Newtonsoft.Json;
using Microsoft.Maui.Essentials;

using Back2LearnMauiApp.Models;

namespace Back2LearnMauiApp.Services
{
    public class CountriesService
    {
        static string key = "icebeam";
        static string serviceBaseUrl = "http://api.geonames.org/";
        static string serviceInfo = $"countryInfoJSON?username={key}";

        private static HttpClient CreateClient(string url)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        private static HttpClient client = CreateClient(serviceBaseUrl);

        public async static Task<List<Country>> GetCountries()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var response = await client.GetAsync(serviceInfo);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var geo = JsonConvert.DeserializeObject<GeoCountry>(json);
                    return geo.Geonames;
                }
            }

            return new List<Country>();
        }
    }
}
