using RiotSharp.SummonerEndpoint;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
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
        [ResponseType(typeof(List<SummonerModel>))]
        public async Task<IHttpActionResult> Get(string SummonerName)
        {
            try
            {
                Summoner summoner = await WebApiApplication.api.GetSummonerAsync(RiotSharp.Region.br, SummonerName);
                SummonerModel model = new SummonerModel()
                {
                    SummonerName = summoner.Name,
                    SummonerId = summoner.Id,
                    SummonerIcon = ReturnUrlChampion(summoner.ProfileIconId),
                    SummonerLevel = summoner.Level
                };

                return Ok(model);

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        private string ReturnUrlChampion(long SummonerId)
        {
            return $"{ConfigurationManager.AppSettings["UrlIconSummoner"]}/{SummonerId}.png";
        }


    }
}
