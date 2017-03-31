using RiotSharp.ChampionEndpoint;
using RiotSharp.MatchEndpoint;
using RiotSharp.StaticDataEndpoint;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
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
    /// Matchs Information
    /// </summary>
    public class MatchListController : ApiController
    {
        /// <summary>
        /// Get Match List of a Summoner
        /// </summary>
        /// <param name="SummonerId"></param>
        /// <returns></returns>

        [ResponseType(typeof(List<MatchModel>))]
        public async Task<IHttpActionResult> Get(int SummonerId)
        {
            List<MatchModel> listmodel = new List<MatchModel>();

            try
            {

                MatchList match = await WebApiApplication.api.GetMatchListAsync(RiotSharp.Region.br, SummonerId, null, null, null, null, null, 0, 20);
                MatchDetail detail = null;
                MatchModel model = null;
                ChampionStatic champ = null;

                foreach (MatchReference item in match.Matches)
                {
                    //Find Match Details based on Summoner Id
                    detail = await WebApiApplication.api.GetMatchAsync(RiotSharp.Region.br, item.MatchID);

                    model = detail.ParticipantIdentities.Where(x => x.Player.SummonerId == SummonerId)
                        .Join(detail.Participants, b => b.ParticipantId, a => a.ParticipantId, (b, a) => new MatchModel { IsWinner = a.Stats.Winner ? "VITÓRIA" : "DERROTA", KdaPlayer = $" {a.Stats.Kills}/{a.Stats.Deaths}/{a.Stats.Assists}" }).FirstOrDefault();

                    //Find Champion Details
                    champ = await WebApiApplication.staticapi.GetChampionAsync(RiotSharp.Region.br, (int)item.ChampionID);
                    model.Champion = new ChampionModel { ChampionId = champ.Id, ChampionName = champ.Name, ChampionIcon = ReturnUrlIcon(champ.Name) };

                    listmodel.Add(model);

                    //Clean objects to new Insert at List
                    detail = null;
                    model = null;
                    champ = null;

                }

                return Ok(listmodel);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }


        /// <summary>
        /// Validation for first letter of a word is a UpperCase
        /// </summary>
        /// <param name="name">Name of Champion</param>
        /// <returns></returns>
        private string ReturnUrlIcon(string name)
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;

            return $"{ConfigurationManager.AppSettings["UrlIconChampion"]}/{myTI.ToTitleCase(name.Replace(" ", string.Empty))}.png";
        }
    }
}
