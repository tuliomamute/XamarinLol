using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinLoL.InternalServices;
using XamarinLoL.Models;
using XamarinLoL.Views;

namespace XamarinLoL
{
    public partial class App : Application
    {
        public static SummonerModel Summoner { get; set; }
        public static NavigationService NavigationService { get; }
       = new NavigationService();

        public App()
        {
            InitializeComponent();
            NavigationService.Configure("MasterMasterDetailPage", typeof(MasterMasterDetailPage));
            NavigationService.Configure("MenuMasterDetailPage", typeof(MenuMasterDetailPage));
            NavigationService.Configure("SummonerProfilePage", typeof(SummonerProfilePage));

            MainPage = new NavigationPage(new XamarinLoL.Views.SearchSummonerPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
