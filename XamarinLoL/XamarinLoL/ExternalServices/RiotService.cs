using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public static async Task<SummonerModel> FindSummoner(string Summoner)
        {
            try
            {
                SummonerModel model = null;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GlobalClasses.GlobalProperties.UrlApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync($"/api/Summoner?Summonername={Summoner}");

                    if (response.IsSuccessStatusCode)
                        model = JsonConvert.DeserializeObject<SummonerModel>(await response.Content.ReadAsStringAsync());

                    return model;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static async Task<ObservableCollection<MatchModel>> FindMatchList(long SummonerId)
        {
            ObservableCollection<MatchModel> model = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalClasses.GlobalProperties.UrlApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var response = await client.GetAsync($"/api/MatchList?SummonerId={(int)SummonerId}"))
                {
                    if (response.IsSuccessStatusCode)
                        model = JsonConvert.DeserializeObject<ObservableCollection<MatchModel>>(await response.Content.ReadAsStringAsync());
                }
            }

            return model;

        }
    }
}
