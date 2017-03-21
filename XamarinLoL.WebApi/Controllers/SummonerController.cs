using RiotSharp.SummonerEndpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace XamarinLoL.WebApi.Controllers
{
    public class SummonerController : ApiController
    {
        public Summoner Get(string SummonerName)
        {
            Summoner summoner = WebApiApplication.api.GetSummonerAsync(RiotSharp.Region.br, SummonerName).Result;
            return summoner;
        }
    }
}
