using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace XamarinLoL.Models
{
    public class MatchModel
    {
        public bool IsWinner { get; set; }
        public string KdaPlayer { get; set; }
        public ChampionModel Champion { get; set; }
    }

    public class ChampionModel
    {
        public int ChampionId { get; set; }

        public string ChampionIcon { get; set; }
        public string ChampionName { get; set; }
    }
}
