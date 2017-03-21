using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinLoL.ViewModel
{
    class SearchSummonerViewModel
    {
        public ICommand Navigate { get; set; }
        public SearchSummonerViewModel()
        {
            Navigate = new Command(() => FindSummoner());
        }

        private void FindSummoner()
        {

        }
    }
}
