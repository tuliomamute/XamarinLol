using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinLoL.ViewModel
{
    [ImplementPropertyChanged]
    public class SummonerProfileViewModel
    {
        public string Imagem { get; set; }
        public string Usuario { get; set; }
        public long Level { get; set; }
        public SummonerProfileViewModel()
        {
            this.Imagem = App.Summoner.SummonerIcon;
            this.Usuario = App.Summoner.SummonerName;
            this.Level = App.Summoner.SummonerLevel;
        }
    }
}
