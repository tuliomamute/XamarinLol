using RiotSharp.SummonerEndpoint;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XamarinLoL.Models;

namespace XamarinLoL.WebApi.Controllers
{
    public class SummonerController : ApiController
    {
        public SummonerModel Get(string SummonerName)
        {
            Summoner summoner = WebApiApplication.api.GetSummonerAsync(RiotSharp.Region.br, SummonerName).Result;
            SummonerModel model = new SummonerModel() { SummonerName = summoner.Name
                , SummonerId = summoner.Id
                , SummonerIcon = ReturnUrlChampion(summoner.Id)
                , SummonerLevel = summoner.Level };

            return model;
        }

        private string ReturnUrlChampion(long SummonerId)
        {
            return $"{ConfigurationManager.AppSettings["UrlIconSummoner"]}/{SummonerId}.png";
        }


    }
}
