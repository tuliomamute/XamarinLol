using RiotSharp.SummonerEndpoint;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using XamarinLoL.Models;

namespace XamarinLoL.WebApi.Controllers
{
    /// <summary>
    /// Summoner Information
    /// </summary>
    public class SummonerController : ApiController
    {
        /// <summary>
        /// Get Summoner Information
        /// </summary>
        /// <param name="SummonerName"></param>
        /// <returns></returns>
        public async Task<SummonerModel> Get(string SummonerName)
        {
            Summoner summoner = await WebApiApplication.api.GetSummonerAsync(RiotSharp.Region.br, SummonerName);
            SummonerModel model = new SummonerModel()
            {
                SummonerName = summoner.Name
                ,
                SummonerId = summoner.Id
                ,
                SummonerIcon = ReturnUrlChampion(summoner.ProfileIconId)
                ,
                SummonerLevel = summoner.Level
            };

            return model;
        }

        private string ReturnUrlChampion(long SummonerId)
        {
            return $"{ConfigurationManager.AppSettings["UrlIconSummoner"]}/{SummonerId}.png";
        }


    }
}
