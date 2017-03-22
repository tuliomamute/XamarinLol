using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using XamarinLoL.Models;

namespace XamarinLoL.ExternalServices
{
    public static class RiotService
    {
        public static async void FindSummoner(string Summoner)
        {
            SummonerModel model = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalClasses.GlobalProperties.UrlApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Summoner");

                if (response.IsSuccessStatusCode)
                    model = JsonConvert.DeserializeObject<SummonerModel>(await response.Content.ReadAsStringAsync());

                App.Summoner = model;

            }
        }
    }
}
