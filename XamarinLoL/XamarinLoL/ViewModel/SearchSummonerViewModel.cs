using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinLoL.ExternalServices;

namespace XamarinLoL.ViewModel
{
    [ImplementPropertyChanged]
    class SearchSummonerViewModel
    {
        public ICommand Navigate { get; set; }
        public string SummonerName { get; set; }
        public SearchSummonerViewModel()
        {
            Navigate = new Command(() => FindSummoner());
        }

        /// <summary>
        /// Method to find a Summoner and navigate
        /// </summary>
        private async void FindSummoner()
        {
            RiotService.FindSummoner(SummonerName);

            App.NavigationService.NavigateTo("MenuMasterDetailPage");
        }
    }
}
