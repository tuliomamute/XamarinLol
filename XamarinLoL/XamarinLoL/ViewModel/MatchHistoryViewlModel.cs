using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using XamarinLoL.ExternalServices;
using XamarinLoL.Models;

namespace XamarinLoL.ViewModel
{
    [ImplementPropertyChanged]
    public class MatchHistoryViewlModel
    {
        public ObservableCollection<MatchModel> matchs { get; set; }
        public bool Refresh { get; set; }
        public MatchHistoryViewlModel()
        {
            BuscarPartidas();
        }

        private void BuscarPartidas()
        {
            Refresh = true;
            matchs = RiotService.FindMatchList(App.Summoner.SummonerId).Result;
            Refresh = false;
        }

    }
}
