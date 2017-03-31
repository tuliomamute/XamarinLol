using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinLoL.ExternalServices;
using XamarinLoL.Models;

namespace XamarinLoL.ViewModel
{
    [ImplementPropertyChanged]
    public class MatchHistoryViewlModel
    {
        public ObservableCollection<MatchModel> Matchs { get; set; }
        public bool Refresh { get; set; }
        public ICommand GetRefreshedHistory { get; set; }
        public MatchHistoryViewlModel()
        {
            BuscarPartidas();
            GetRefreshedHistory = new Command(() => BuscarPartidas());
        }

        private void BuscarPartidas()
        {
            Refresh = true;
            Matchs = RiotService.FindMatchList(App.Summoner.SummonerId).Result;
            Refresh = false;
        }

    }
}
